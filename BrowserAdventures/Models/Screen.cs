using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class Screen
    {
        public int ScreenID { get; set; }
        public string ScreenName { get; set; }
        public string ScreenDescription { get; set; }

        public ICollection<ScreenItem> ScreenInventory { get; set; }
        public ICollection<ScreenEnemy> ScreenEnemies { get; set; }

    }
}
