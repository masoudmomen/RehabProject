using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public class FacilityCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string CardImage { get; set; } = string.Empty;
        public  int InsuranceCount { get; set; }
        public  int AccreditationCount { get; set; }
        public  int AmenityCount { get; set; }
        public  int HighlightCount { get; set; }
        public  int WwtCount { get; set; }
        public  int TreatmentCount { get; set; }
        public  int ConditionCount { get; set; }
        public  int SwtCount { get; set; }
    }
}
