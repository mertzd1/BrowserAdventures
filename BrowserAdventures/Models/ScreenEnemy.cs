using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class ScreenEnemy
    {
        public int ScreenEnemyID { get; set; }
        public int ScreenID { get; set; }
        public int EnemyID { get; set; }
        public string ScreenEnemyAction { get; set; }
        public string EnemyDescription { get; set; }

    }
}
