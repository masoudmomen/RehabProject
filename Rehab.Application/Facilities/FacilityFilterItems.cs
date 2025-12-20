using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public class FacilityFilterItems
    {
        public List<int> Amenities { get; set; } = new();
        public List<int> Insurances { get; set; } = new();
        public List<int> Accreditations { get; set; } = new();
        public List<int> Highlights { get; set; } = new();
        public List<int> Wwts { get; set; } = new();
        public List<int> Treatments { get; set; } = new();
        public List<int> Swts { get; set; } = new();
    }
}
