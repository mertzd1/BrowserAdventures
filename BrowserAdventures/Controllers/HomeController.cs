using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BrowserAdventures.Models;
using BrowserAdventures;
using browsersqlserver.database.windows;
using Microsoft.EntityFrameworkCore;
using BrowserAdventures.Infrastructure;

namespace BrowserAdventures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BrowserAdventureContext _context;

        public HomeController(ILogger<HomeController> logger, BrowserAdventureContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login(User user)
        {
            User verifiedUser = _context.User.Include(u => u.InventoryItems).Where(u => u.Name == user.Name).FirstOrDefault();
            if (verifiedUser == null)
            {
                user.Health = 30;
                user.Level = 1;
                user.Experience = 0;
                user.Screen = 1;
                Item item = _context.Item.Where(i => i.ItemName == "Apple").Single();
                user.Inventory.Add(item);
                
                _context.User.Add(user);
                
                _context.SaveChanges();
                verifiedUser = _context.User.Where(u => u.Name == user.Name).FirstOrDefault();
                _context.InventoryItems.Add(new InventoryItem { ItemID = item.ItemID, UserID = verifiedUser.UserID, Quantity = 2 });
                _context.FightLogs.Add(new FightLog { UserID = verifiedUser.UserID, Entry = $"{verifiedUser.Name} steps into the world.", EntryType = "normal-event" });
                _context.SaveChanges();
                ResetGameState();
                
            } else
            {
                List<InventoryItem> invItems = _context.InventoryItems.Where(ii => ii.UserID == verifiedUser.UserID).ToList();
                foreach (InventoryItem item in invItems)
                {
                    Item itemToAdd = _context.Item.Where(i => i.ItemID == item.ItemID).FirstOrDefault();
                    //verifiedUser.Inventory.Add(itemToAdd);
                }
            }
            UpdateScreen(verifiedUser);
            SaveUser(verifiedUser);

            /*
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == verifiedUser.Screen).FirstOrDefault();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Where(i => i.ItemID == si.ItemID).FirstOrDefault();
            }
            ConsoleViewModel model = new ConsoleViewModel { User = verifiedUser,
                                                            Log = _context.FightLogs.Where(l => l.UserID == verifiedUser.UserID).ToList(),
                                                            Screen = screen,
                                                            AccessPoints = _context.AccessPoint.Where(a => a.From == verifiedUser.Screen).ToList()};
            */

            return View("Console", BuildModel());
        }

        public void UpdateScreen(User user)
        {
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            screen.ScreenEnemies = _context.ScreenEnemy.Where(se => se.ScreenID == screen.ScreenID).ToList();
            string roomDesc = screen.ScreenDescription;
            foreach (ScreenItem item in screen.ScreenInventory)
            {
                roomDesc += " " + item.ScreenItemDescription;
            }
            foreach (ScreenEnemy enemy in screen.ScreenEnemies)
            {
                roomDesc += " " + enemy.EnemyDescription;
            }
            // TODO: Add enemy description to room description
            _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = roomDesc, EntryType = "normal-event" });
            _context.SaveChanges();
        }

        public IActionResult Travel(int screenID)
        {
            User user = GetUser();

            // Update the screen the user is currently at
            AccessPoint ap = _context.AccessPoint.Where(a => a.To == screenID && a.From == user.Screen).FirstOrDefault();
            AccessRequirements ar = _context.AccessRequirements.Where(a => a.AccessPointID == ap.AccessPointID).FirstOrDefault();
            bool requirementMet = false;
            if (ar != null)
            {
                foreach (Item item in user.Inventory)
                {
                    if (item.ItemID == ar.RequiredItemID) requirementMet = true;
                }
            } else
            {
                requirementMet = true;
            }

            if (requirementMet && ar != null)
            {
                _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = ar.OpenMessage, EntryType = "normal-event" });
            } else if (!requirementMet && ar != null)
            {
                _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = ar.ClosedMessage, EntryType = "normal-event" });
                UpdateScreen(user);
                _context.SaveChanges();
                return View("Console", BuildModel());

            }
            user.Screen = screenID;
            UpdateScreen(user);
            SaveUser(user);
            _context.User.Update(user);
            _context.SaveChanges();

            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Where(i => i.ItemID == si.ItemID).FirstOrDefault();
            }
            ConsoleViewModel model = new ConsoleViewModel();
            model.User = user;
            model.Log = _context.FightLogs.Where(l => l.UserID == user.UserID).ToList();
            model.AccessPoints = _context.AccessPoint.Where(a => a.From == user.Screen).ToList();
            model.Screen = screen;


            return View("Console", BuildModel());
        }

        public IActionResult Attack(int screenEnemyID)
        {
            // Roll enemy damage
            // I want the enemy to attack first so you dont kill it before it gets a chance to hit you.
            ScreenEnemy screenEnemy = _context.ScreenEnemy.Where(se => se.ScreenEnemyID == screenEnemyID).FirstOrDefault();
            Enemy enemy = _context.Enemy.Where(e => e.EnemyID == screenEnemy.EnemyID).FirstOrDefault();
            int enemyDamage = enemy.EnemyModifier;
            Random rand = new Random();
            for (int r = 0; r < enemy.EnemyMultipler; r++)
            {
                enemyDamage += rand.Next(1, enemy.EnemyDie + 1);
            }
            User user = GetUser();

            user.Health -= enemyDamage;
            string fight = $"A {enemy.EnemyName} attacks you, doing {enemyDamage} HP damage.<br />";

            // Roll player damage
            Item weapon = new Item();
            foreach (Item item in user.Inventory)
            {
                if (item.ItemID == user.WeaponID) weapon = item;
            }
            Weapon sickle = _context.Weapons.Where(w => w.ItemID == weapon.ItemID).FirstOrDefault();
            // For now, just using static numbers to get combat to display properly
            int userDamage = sickle.WeaponModifier;
            for (int r = 0; r < sickle.WeaponMultipler; r++)
            {
                userDamage += rand.Next(1, sickle.WeaponDie + 1);
            }

            fight += $"You attack a {enemy.EnemyName} with your {weapon.ItemName} for {userDamage} HP damage.<br />";
            _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = fight, EntryType = "combat" });
            enemy.EnemyHealth -= userDamage;
            if (enemy.EnemyHealth <= 0)
            {
                string exp = $"You killed a {enemy.EnemyName}! You gained {enemy.EnemyExperience} experience points.";
                user.Experience += enemy.EnemyExperience;
                _context.ScreenEnemy.Remove(screenEnemy);
                _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = exp, EntryType = "experience" });
            }

            _context.User.Update(user);
            SaveUser(user);
            _context.SaveChanges();

            UpdateScreen(user);
            return View("Console", BuildModel());
        }

        public IActionResult Open(int itemID)
        {
            // TODO: Actions taken when opening

            /*
            Item item = _context.Item.Where(i => i.ItemID == itemID).FirstOrDefault();
            ItemType type = _context.ItemType.Where(i => i.ItemTypeID == item.ItemTypeID).FirstOrDefault();
            User user = GetUser();
            
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            Chest chest = new Chest();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Where(i => i.ItemID == si.ItemID).FirstOrDefault();
                chest.ParentContainer = si.Item;
                List<InventoryItem> items = _context.InventoryItems.Where(i => i.ScreenItemID == si.ScreenItemID).ToList();
                foreach (InventoryItem inv in items)
                {
                    chest.ItemsInside.Add(inv.InventoryItemID, _context.Item.Where(i => i.ItemID == inv.ItemID).FirstOrDefault());
                }
            }

            string openDesc = $"You open the {type.ItemTypeName} and look in.";
            if (chest.ItemsInside == null)
            {
                openDesc += " You don't see anything.";
            } else
            {
                foreach (KeyValuePair<int, Item> chestItem in chest.ItemsInside)
                {
                    openDesc += " " + chestItem.Value.ItemDescription;
                }
            }
            // TODO: Append items in container to description
            FightLog f = new FightLog { UserID = user.UserID, Entry = openDesc };
            _context.FightLogs.Add(f);
            _context.SaveChanges();
            */
            BuildOpenViewDescription(itemID);
            return View("Open", BuildModel());
        }

        public IActionResult Close(ConsoleViewModel model)
        {
            UpdateScreen(GetUser());
            return View("Console", BuildModel());
        }

        public IActionResult Take(int inventoryItemID, int itemID, int chestID)
        {
            // TODO: Actions taken when taking
            User user = GetUser();

            Item takenItem = _context.Item.Where(i => i.ItemID == itemID).FirstOrDefault();
            InventoryItem inv = new InventoryItem();
            if (inventoryItemID == 0)
            {
                inv.ItemID = itemID;
                inv.UserID = user.UserID;
                inv.Quantity = 1;
                _context.InventoryItems.Add(inv);
                ScreenItem se = _context.ScreenItem.Where(s => s.ScreenID == user.Screen && s.ItemID == itemID).FirstOrDefault();
                _context.ScreenItem.Remove(se);
            } else { 
                inv.InventoryItemID = inventoryItemID;
                inv.ItemID = itemID;
                inv.UserID = user.UserID;
                inv.Quantity = 1;
                _context.InventoryItems.Update(inv);
            }
            user.Inventory.Add(takenItem);
            ItemType type = _context.ItemType.Where(t => t.ItemTypeID == takenItem.ItemTypeID).FirstOrDefault();
            if (type.ItemTypeName == "Weapon")
            {
                user.WeaponEquipped = true;
                user.WeaponID = takenItem.ItemID;
            }
            SaveUser(user);
            FightLog f = new FightLog { UserID = user.UserID, Entry = $"You added the {takenItem.ItemName} to your inventory.", EntryType = "normal-event" };
            _context.FightLogs.Add(f);
            _context.User.Update(user);
            _context.SaveChanges();
            if (chestID == 0)
            {
                UpdateScreen(user);
                return View("Console", BuildModel());
            } else { 
                BuildOpenViewDescription(chestID);
            
                return View("Open", BuildModel());
            }
        }

        public IActionResult Eat(Item item)
        {
            User user = GetUser();
            int maxHP = user.Level * 30;
            Consumable consumable = _context.Consumables.Where(c => c.ItemID == item.ItemID).SingleOrDefault();
            user.Health = Math.Min(user.Health + consumable.Heals, maxHP);
            InventoryItem invItem = _context.InventoryItems.Where(ii => ii.UserID == user.UserID && ii.ItemID == item.ItemID).SingleOrDefault();
            invItem.Quantity -= 1;
            if (invItem.Quantity == 0)
            {
                _context.InventoryItems.Remove(invItem);
            } else
            {
                _context.InventoryItems.Update(invItem);
            }
            foreach (InventoryItem iItem in user.InventoryItems)
            {
                if (iItem.InventoryItemID == invItem.InventoryItemID)
                {
                    iItem.Quantity -= 1;
                    if (iItem.Quantity == 0) {
                        Item removedItem = null;
                        foreach (Item i in user.Inventory)
                        {
                            if (i.ItemID == iItem.ItemID) removedItem = i;
                        }
                        user.Inventory.Remove(removedItem);
                        invItem = iItem;
                        
                    }
                }
            }
            if (invItem.Quantity == 0) user.InventoryItems.Remove(invItem);
            _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = consumable.ConsumeMessage, EntryType = "consume" });
            
            /*
            if (invItem.Quantity == 0)
            {
                _context.InventoryItems.Remove(invItem);
                user.InventoryItems.Remove(invItem);
                user.Inventory.Remove(item);

            }
            */
            _context.SaveChanges();
            SaveUser(user);
            return RedirectToAction("Close", BuildModel());
        }

        public ConsoleViewModel BuildModel()
        {
            User user = GetUser();
            /*
            if (user.Inventory.Count == 0) { 
            List<InventoryItem> invItems = _context.InventoryItems.Where(ii => ii.UserID == user.UserID).ToList();
            foreach (InventoryItem item in invItems)
            {
                user.Inventory.Add(_context.Item.Where(i => i.ItemID == item.ItemID).FirstOrDefault());
            }
            }
            */
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            
            /*
            List<InventoryItem> inventory = _context.InventoryItems.Where(inv => inv.UserID == user.UserID).ToList();
            foreach (InventoryItem invItem in inventory)
            {
                user.Inventory.Add(_context.Item.Where(i => i.ItemID == invItem.ItemID).FirstOrDefault());
            }
            SaveUser(user);
            */

            Chest chest = new Chest();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Where(i => i.ItemID == si.ItemID).FirstOrDefault();
                chest.ParentContainer = si.Item;
                List<InventoryItem> items = _context.InventoryItems.Where(i => i.ScreenItemID == si.ScreenItemID).ToList();
                foreach (InventoryItem inv in items)
                {
                    chest.ItemsInside.Add(inv.InventoryItemID, _context.Item.Where(i => i.ItemID == inv.ItemID).FirstOrDefault());
                }
            }
            ConsoleViewModel model = new ConsoleViewModel();
            model.User = user;
            model.Log = _context.FightLogs.Where(l => l.UserID == user.UserID).ToList();
            model.AccessPoints = _context.AccessPoint.Where(a => a.From == user.Screen).ToList();
            model.Screen = screen;
            model.Chest = chest;
            return model;
        }

        public void BuildOpenViewDescription(int itemID)
        {
            Item item = _context.Item.Where(i => i.ItemID == itemID).FirstOrDefault();
            ItemType type = _context.ItemType.Where(i => i.ItemTypeID == item.ItemTypeID).FirstOrDefault();
            User user = GetUser();

            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            Chest chest = new Chest();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Where(i => i.ItemID == si.ItemID).FirstOrDefault();
                chest.ParentContainer = si.Item;
                List<InventoryItem> items = _context.InventoryItems.Where(i => i.ScreenItemID == si.ScreenItemID).ToList();
                foreach (InventoryItem inv in items)
                {
                    chest.ItemsInside.Add(inv.InventoryItemID, _context.Item.Where(i => i.ItemID == inv.ItemID).FirstOrDefault());
                }
            }

            string openDesc = $"You open the {type.ItemTypeName} and look in.";
            if (chest.ItemsInside == null || chest.ItemsInside.Count == 0)
            {
                openDesc += " You don't see anything.";
            }
            else
            {
                foreach (KeyValuePair<int, Item> chestItem in chest.ItemsInside)
                {
                    openDesc += " " + chestItem.Value.ItemDescription;
                }
            }
            // TODO: Append items in container to description
            FightLog f = new FightLog { UserID = user.UserID, Entry = openDesc, EntryType = "normal-event" };
            _context.FightLogs.Add(f);
            _context.SaveChanges();
        }

        private void SaveUser(User user)
        {
            HttpContext.Session.SetJson("User", user);
        }

        private User GetUser()
        {
            User user = HttpContext.Session.GetJson<User>("User") ?? new User();
            return user;
        }

        private void ResetGameState()
        {
            // Add another sickle if none
            if (!_context.ScreenItem.Where(s => s.ScreenID == 2).Any())
            {
                _context.ScreenItem.Add(new ScreenItem
                {
                    //ScreenItemID = 2,
                    ScreenID = 2,
                    ItemID = 3,
                    ScreenItemDescription = "A sickle, serviceable, though lightly rusted, rests against one wall.",
                    ScreenItemAction = "Take the sickle for protection"
                });
                _context.SaveChanges();
            }

            // Add another gate key
            if (!_context.InventoryItems.Where(i => i.ScreenItemID == 1).Any())
            {
                _context.InventoryItems.Add(new InventoryItem
                {
                    ItemID = 2,
                    ScreenItemID = 1
                });
                _context.SaveChanges();
            }
        }
    }
}
