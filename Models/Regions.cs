using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ziibdApp.Models
{
    public partial class Regions
    {
        public Regions()
        {
            Countries = new HashSet<Countries>();
        }

        public decimal RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}
