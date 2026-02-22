using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Conditions;
using Rehab.Application.Insurances;
using Rehab.Application.LevelsOfCare;
using Rehab.Application.SubstancesWeTreat;
using Rehab.Application.Treatments;
using Rehab.Application.WhoWeTreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public class FullFacilityFilterItemsDto
    {
        public string SearchText { get; set; } = string.Empty;
        public List<string> States { get; set; } = new();
        public List<ConditionDto> Conditions { get; set; }= new();
        public List<TreatmentDto> Treatments { get; set; } = new();
        public List<WwtDto> Wwts { get; set; } = new();
        public List<LevelsOfCareDto> Locs { get; set; } = new();
        public List<InsuranceDto> Insurances { get; set; } = new();
        public List<AmenityDto> Amenities { get; set; } = new();
        public List<SwtDto> Swts { get; set; } = new();
        public List<AccreditationDto> Accreditations { get; set; } = new();
    }
}
