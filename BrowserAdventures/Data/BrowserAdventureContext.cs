using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrowserAdventures.Models;

namespace browsersqlserver.database.windows
{
    public class BrowserAdventureContext : DbContext
    {
        public BrowserAdventureContext(DbContextOptions<BrowserAdventureContext> options)
            : base(options)
        {
        }

        public DbSet<AccessPoint> AccessPoint { get; set; }
        public DbSet<AccessRequirements> AccessRequirements { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<FightLog> FightLogs { get; set; }
        public DbSet<InventoryItem> InventoryItems {get; set;}
        public DbSet<User> User { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<ItemType> ItemType { get; set; }

        public DbSet<Screen> Screen { get; set; }

        public DbSet<ScreenItem> ScreenItem { get; set; }

        public DbSet<Enemy> Enemy { get; set; }

        public DbSet<ScreenEnemy> ScreenEnemy { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
