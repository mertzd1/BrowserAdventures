using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserAdventures.Models
{
    public class AccessRequirements
    {
        public int AccessRequirementsID { get; set; }
        
        public int AccessPointID { get; set; }
        public string ClosedMessage { get; set; }
        public string OpenMessage { get; set; }

        public int RequiredItemID { get; set; }

    }
}
