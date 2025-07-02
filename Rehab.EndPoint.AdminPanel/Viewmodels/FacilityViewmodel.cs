using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.Treatments;
using Rehab.Domain.WhoWeTreat;
using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.AdminPanel.Viewmodels
{
    public class FacilityViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public string ProvidersPolicy { get; set; } = string.Empty;
        public short Founded { get; set; }
        public short OccupancyMin { get; set; }
        public short OccupancyMax { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public string Logo { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;

        public List<InsuranceViewmodel>? Insurances { get; set; } = new();
        public List<AccreditationViewmodel>? Accreditations { get; set; } = new();
        public List<AmenityViewmodel>? Amenities { get; set; } = new();
        public List<HighlightViewmodel>? Highlights { get; set; } = new();
        public List<FacilitysImages>? FacilitysImages { get; set; } = new();
        public List<LocViewmodel>? Locs { get; set; } = new();
        public List<TreatmentViewmodel>? Treatments { get; set; } = new();
        public List<WwtViewmodel>? Wwts { get; set; } = new();
    }
}
