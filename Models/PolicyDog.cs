using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBQWebsite.Models
{
    public partial class PolicyDog
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string BreedId { get; set; }
        public string CoverageLevelId { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string PolicyId { get; set; }
        public string UserId { get; set; }


    }
}
