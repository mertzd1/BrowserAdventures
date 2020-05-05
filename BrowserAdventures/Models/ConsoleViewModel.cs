using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class ConsoleViewModel
    {
        public User User { get; set; }
        public List<FightLog> Log { get; set; }
        public Screen Screen { get; set; }

        public List<AccessPoint> AccessPoints { get; set; }

        public Chest Chest { get; set; }
    }
}
