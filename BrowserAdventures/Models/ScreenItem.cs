using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class ScreenItem
    {
        public int ScreenItemID { get; set; }
        public int ScreenID { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public string ScreenItemDescription { get; set; }
        public string ScreenItemTakenDescription { get; set; }
        public string ScreenItemAction { get; set; }
    }
}
