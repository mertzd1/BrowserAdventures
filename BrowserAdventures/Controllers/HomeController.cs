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
            User verifiedUser = _context.User.Where(u => u.Name == user.Name).FirstOrDefault();
            if (verifiedUser == null)
            {
                user.Health = 30;
                user.Level = 1;
                user.Experience = 0;
                user.Screen = 1;
                _context.User.Add(user);
                
                _context.SaveChanges();
                verifiedUser = _context.User.Where(u => u.Name == user.Name).FirstOrDefault();
                _context.FightLogs.Add(new FightLog { UserID = verifiedUser.UserID, Entry = $"{verifiedUser.Name} steps into the world." });
                _context.SaveChanges();
                
            }
            UpdateScreen(verifiedUser);
            SaveUser(verifiedUser);
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == verifiedUser.Screen).FirstOrDefault();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Where(i => i.ItemID == si.ItemID).FirstOrDefault();
            }
            ConsoleViewModel model = new ConsoleViewModel { User = verifiedUser,
                                                            Log = _context.FightLogs.Where(l => l.UserID == verifiedUser.UserID).ToList(),
                                                            Screen = screen,
                                                            AccessPoints = _context.AccessPoint.Where(a => a.From == verifiedUser.Screen).ToList()};
            
            return View("Console", model);
        }

        public void UpdateScreen(User user)
        {
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            string roomDesc = screen.ScreenDescription;
            foreach (ScreenItem item in screen.ScreenInventory)
            {
                roomDesc += " " + item.ScreenItemDescription;
            }
            // TODO: Add enemy description to room description
            _context.FightLogs.Add(new FightLog { UserID = user.UserID, Entry = roomDesc });
            _context.SaveChanges();
        }

        public IActionResult Travel(int screenID)
        {
            User user = GetUser();
            // Update the screen the user is currently at
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


            return View("Console", model);
        }

        public IActionResult Open(int itemID)
        {
            // TODO: Actions taken when opening
            User user = GetUser();
            FightLog f = new FightLog { UserID = user.UserID, Entry = "Test open action method sat" };
            _context.FightLogs.Add(f);
            _context.SaveChanges();
            ConsoleViewModel model = new ConsoleViewModel();
            model.User = user;
            model.Log = _context.FightLogs.Where(l => l.UserID == user.UserID).ToList();
            model.AccessPoints = _context.AccessPoint.Where(a => a.From == user.Screen).ToList();
            Screen screen = _context.Screen.Include(s => s.ScreenInventory).Where(s => s.ScreenID == user.Screen).FirstOrDefault();
            Chest chest = new Chest();
            foreach (ScreenItem si in screen.ScreenInventory)
            {
                si.Item = _context.Item.Include(i => i.ContainerInventory).Where(i => i.ItemID == si.ItemID).FirstOrDefault();
                foreach (InventoryItem inv in si.Item.ContainerInventory)
                {
                    chest.Item = _context.Item.Where(i => i.ItemID == inv.ItemID).FirstOrDefault();
                }
            }
            model.Screen = screen;
            model.Chest = chest;
            return View("Open", model);
        }

        public IActionResult Close(int itemID)
        {
            return View("Console");
        }

        public IActionResult Take(int itemID)
        {
            // TODO: Actions taken when taking
            return View("Console");
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
    }
}
