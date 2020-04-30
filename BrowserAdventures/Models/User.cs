using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }
        public int Screen { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }

    }
}
