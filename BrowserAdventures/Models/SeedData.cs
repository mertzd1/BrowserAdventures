using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using browsersqlserver.database.windows;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrowserAdventures.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BrowserAdventureContext(
                serviceProvider.GetRequiredService<DbContextOptions<BrowserAdventureContext>>()))
            {
                // Screens
                if (!context.Screen.Any())
                {
                    context.Screen.AddRange(
                        new Screen
                        {
                            //ScreenID = 1,
                            ScreenName = "A fork in the road",
                            ScreenDescription = "You stand at the end of a wide road which continues to the west. The barren wilderness from whence you came lies to the east and south. To the north you see a broad field surrounded by a tall fence and accessible only through a gate."
                        },
                        new Screen
                        {
                            //ScreenID = 2,
                            ScreenName = "A broad field",
                            ScreenDescription = "You stand in a broad field, freshly tilled but devoid of crops. The only exit lies south and leads to the end of a wide road."
                        },
                        new Screen
                        {
                            // ScreenID = 3,
                            ScreenName = "A wide road",
                            ScreenDescription = "You stand on a wide road which continues as far as you can see to the west. The road ends a short way east."
                        }
                        );
                }

                // Access Point
                if (!context.AccessPoint.Any())
                {
                    context.AccessPoint.AddRange(
                        new AccessPoint
                        {
                            //AccessPointID = 1,
                            To = 2,
                            From = 1,
                            Description = "Enter the field"
                        },
                        new AccessPoint
                        {
                            // AccessPointID = 2,
                            To = 1,
                            From = 2,
                            Description = "Leave the field"
                        },
                        new AccessPoint
                        {
                            // AccessPointID = 3,
                            To = 3,
                            From = 1,
                            Description = "Travel west"
                        },
                        new AccessPoint
                        {
                            // AccessPointID = 4,
                            To = 1,
                            From = 3,
                            Description = "Travel east"
                        }
                        );
                }

                //AccessRequirements
                if (!context.AccessRequirements.Any())
                {
                    context.AccessRequirements.Add(
                        new AccessRequirements
                        {
                            // AccessRequirementID = 1,
                            AccessPointID = 1,
                            ClosedMessage = "The locked gate bars your way.",
                            OpenMessage = "The gate opens quietly. It must be used frequently.",
                            RequiredItemID = 2
                        }
                        );
                }

                // Item Types
                if (!context.ItemType.Any())
                {
                    context.ItemType.AddRange(
                        new ItemType
                        {
                            //ItemTypeID = 1,
                            ItemTypeName = "Chest"
                        },
                        new ItemType
                        {
                            // ItemTypeID = 2,
                            ItemTypeName = "Key"
                        },
                        new ItemType
                        {
                            // ItemTypeID = 3,
                            ItemTypeName = "Weapon"
                        },
                        new ItemType
                        {
                            // ItemTypeID = 4,
                            ItemTypeName = "Consumable"
                        }
                        );
                    context.SaveChanges();
                }

                // Weapons
                if (!context.Weapons.Any())
                {
                    context.Weapons.Add(
                        new Weapon
                        {
                            // WeaponID = 1
                            ItemID = 3,
                            WeaponMultipler = 2,
                            WeaponDie = 2,
                            WeaponModifier = 1
                        }
                        );
                    context.SaveChanges();
                }
                
                // Items
                if (!context.Item.Any())
                {
                    context.Item.Add(
                        new Item
                        {
                            //ItemID = 1,
                            ItemTypeID = 1,
                            ItemName = "small chest",
                            ItemDescription = "A small chest sits on the ground by the fence.",
                            Container = true
                        });
                    context.SaveChanges();
                    context.Item.Add(
                        new Item
                        {
                            //ItemID = 2,
                            ItemTypeID = 2,
                            ItemName = "Gate key",
                            ItemDescription = "A key sits at the bottom of the chest. It looks like it might fit a gate.",
                            Container = false
                        }
                        );
                    context.SaveChanges();
                    context.Item.Add(
                        new Item
                        {
                            // ItemID = 3,
                            ItemTypeID = 3,
                            ItemName = "Rusty sickle",
                            ItemDescription = "A rusty sickle, perfect for killing malnourished bandits.",
                            Container = false
                        }
                        );
                    context.SaveChanges();
                    context.Item.Add(
                        new Item
                        {
                            // ItemID = 4,
                            ItemTypeID = 4,
                            ItemName = "Apple",
                            ItemDescription = "A juicy, red apple.",
                            Container = false
                        }
                        );
                    context.SaveChanges();

                }

                // Consumables
                if (!context.Consumables.Any())
                {
                    context.Consumables.Add(
                        new Consumable
                        {
                            // ConsumableID = 1,
                            ItemID = 4,
                            Heals = 10,
                            ConsumeMessage = "You eat a juicy, red apple. You feel much better!"
                        }
                        );
                    context.SaveChanges();
                }
                
                // Screen Items
                if (!context.ScreenItem.Any())
                {
                    context.ScreenItem.Add(
                        new ScreenItem
                        {
                            //ScreenItemID = 1,
                            ScreenID = 1,
                            ItemID = 1,
                            ScreenItemDescription = "A small chest sits on the ground by the fence.",
                            ScreenItemAction = "Open the chest"
                        }
                        );
                    context.SaveChanges();
                    context.ScreenItem.Add(
                        new ScreenItem
                        {
                            //ScreenItemID = 2,
                            ScreenID = 2,
                            ItemID = 3,
                            ScreenItemDescription = "A sickle, serviceable, though lightly rusted, rests against one wall.",
                            ScreenItemAction = "Take the sickle for protection"
                        }
                        );
                    
                }
                

                
                //InventoryItems
               if (!context.InventoryItems.Any())
                {
                    context.InventoryItems.Add(
                        new InventoryItem
                        {
                            //InventoryItemID = 1,
                            ItemID = 2,
                            ScreenItemID = 1
                        }
                        );
                    context.SaveChanges();
                    
                }
                
                // Enemies
                if (!context.Enemy.Any())
                {
                    context.Enemy.Add(
                        new Enemy
                        {
                            //EnemyID = 1,
                            EnemyName = "Malnourished Bandit",
                            
                            EnemyHealth = 2,
                            EnemyMultipler = 1,
                            EnemyDie = 2,
                            EnemyModifier = -1,
                            EnemyExperience = 10
                        }
                        );
                    context.SaveChanges();
                }

                // Screen Enemies
                if (!context.ScreenEnemy.Any())
                {
                    context.ScreenEnemy.Add(
                        new ScreenEnemy
                        {
                            //ScreenEnemyID = 1,
                            ScreenID = 3,
                            EnemyID = 1,
                            EnemyDescription = "A <abbr title=\"A bandit so gaunt, you'd almost rather give him your money than fight over it. Almost.\">Malnourished Bandit</abbr> blocks your path.",
                            ScreenEnemyAction = "Attack the Malnourished Bandit"
                        }
                        );
                    context.SaveChanges();

                }
            }
        }
    }
}
