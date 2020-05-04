using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using browsersqlserver.database.windows;
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
                        }
                        );
                }
                // Items
                if (!context.Item.Any())
                {
                    context.Item.AddRange(
                        new Item
                        {
                            //ItemID = 1,
                            ItemTypeID = 1,
                            ItemName = "A small chest"
                        }
                        );
                    
                }
                // Screen Items
                if (!context.ScreenItem.Any())
                {
                    context.ScreenItem.AddRange(
                        new ScreenItem
                        {
                            //ScreenItemID = 1,
                            ScreenID = 1,
                            ItemID = 1,
                            ScreenItemDescription = "A small chest sits on the ground by the fence."
                        }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
