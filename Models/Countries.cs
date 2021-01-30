using System.Collections.Generic;

namespace ziibdApp.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Locations = new HashSet<Locations>();
        }

        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal? RegionId { get; set; }

        public virtual Regions Region { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
