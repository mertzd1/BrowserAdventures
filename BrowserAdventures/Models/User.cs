using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class User
    {
        public User()
        {
            Inventory = new List<Item>();
        }
        public int UserID { get; set; }

        public string Name { get; set; }
        public int Screen { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public bool WeaponEquipped { get; set; }
        public int WeaponID { get; set; }

        public ICollection<InventoryItem> InventoryItems { get; set; }

        public List<Item> Inventory { get; set; }

    }
}
