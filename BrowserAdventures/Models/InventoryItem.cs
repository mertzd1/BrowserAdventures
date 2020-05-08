using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class InventoryItem
    {
        public int InventoryItemID { get; set; }
        public int? UserID { get; set; }
        public int ItemID { get; set; }
        //public Item Item { get; set; }
        public int ScreenItemID { get; set; }
        public int Quantity { get; set; }
    }
}
