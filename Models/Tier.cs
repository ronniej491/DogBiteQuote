using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBQWebsite.Models
{
    public partial class Tier
    {
        public int ID { get; set; }
        public string TierCode { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
