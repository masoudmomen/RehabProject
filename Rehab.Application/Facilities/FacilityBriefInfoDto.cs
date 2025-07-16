using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Highlights;
using Rehab.Application.Insurances;
using Rehab.Domain.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public class FacilityBriefInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }
}
