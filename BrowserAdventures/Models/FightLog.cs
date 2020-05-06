using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class FightLog
    {
        public int FightLogID { get; set; }
        public int UserID { get; set; }
        public int ScreenEnemyID { get; set; }
        public int DamageDone { get; set; }
        public string Entry { get; set; }
        public string EntryType { get; set; }
    }
}
