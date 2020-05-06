using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class Enemy
    {
        public int EnemyID { get; set; }
        public string EnemyName { get; set; }
        public string EnemyDescription { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyMultipler { get; set; }
        public int EnemyDie { get; set; }
        public int EnemyModifier { get; set; }
        public int EnemyExperience { get; set; }

        
    }
}
