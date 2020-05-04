using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class Weapon
    {
        public int WeaponID { get; set; }
        public int ItemID { get; set; }
        public int WeaponMultipler { get; set; }
        public int WeaponDie { get; set; } 
        public int WeaponModifier { get; set; }
    }
}
