using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class Chest
    {

        public Chest()
        {
            ItemsInside = new Dictionary<int, Item>();
        }
        public Dictionary<int, Item> ItemsInside { get; set; }
        public Item ParentContainer { get; set; }
        
    }
}
