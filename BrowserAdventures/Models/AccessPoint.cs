using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class AccessPoint
    {
        
        public int AccessPointID { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Description { get; set; }
    }
}
