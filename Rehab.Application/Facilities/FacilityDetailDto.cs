using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Conditions;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.SubstancesWeTreat;
using Rehab.Domain.Treatments;
using Rehab.Domain.WhoWeTreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public class FacilityDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProvidersPolicy { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public short Founded { get; set; }
        public short OccupancyMin { get; set; }
        public short OccupancyMax { get; set; }

        public List<Insurance>? Insurances { get; set; }
        public List<Accreditation>? Accreditations { get; set; }
        public List<Amenity>? Amenities { get; set; }
        public List<Highlight>? Highlights { get; set; }
        public List<FacilitysImages>? FacilitysImages { get; set; }
        public List<Loc>? Locs { get; set; }
        public List<Treatment>? Treatments { get; set; }
        public List<Wwt>? Wwts { get; set; }
        public List<Condition>? Conditions { get; set; }
        public List<Swt>? Swts { get; set; }
    }
}
