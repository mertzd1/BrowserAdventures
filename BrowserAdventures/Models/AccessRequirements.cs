using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class AccessRequirements
    {
        public int AccessRequirementID { get; set; }
        
        public int AccessPointID { get; set; }
        public string ClosedMessage { get; set; }
        public string OpenMessage { get; set; }

    }
}
