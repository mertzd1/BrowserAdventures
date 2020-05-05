using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public int ItemTypeID { get; set; }
        public string ItemName { get; set; }

        public bool Container { get; set; }
        public ICollection<InventoryItem> ContainerInventory { get; set; }
    }
}
