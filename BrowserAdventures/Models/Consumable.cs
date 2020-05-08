using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class Consumable
    {
        public int ConsumableID { get; set; }
        public int ItemID { get; set; }
        public int Heals { get; set; }
        public string ConsumeMessage { get; set; }
    }
}
