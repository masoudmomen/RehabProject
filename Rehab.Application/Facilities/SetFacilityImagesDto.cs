using Rehab.Domain.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public class SetFacilityImagesDto
    {
        public int FacilityId { get; set; }
        public string Logo { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public List<FacilityImagesDto>? FacilityImages { get; set; }
    }

    public class FacilityImagesDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageAddress { get; set; } = string.Empty;
    }
}
