using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.Treatments;
using Rehab.Domain.WhoWeTreat;

namespace Rehab.Application.Facilities
{
    public class AddRequestFacilityDto
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

        public List<int>? InsurancesId { get; set; } = new();
        public List<int>? AccreditationsId { get; set; } = new();
        public List<int>? AmenitiesId { get; set; } = new();
        public List<int>? HighlightsId { get; set; } = new();
        public List<int>? LocsId { get; set; } = new();
        public List<int>? TreatmentsId { get; set; } = new();
        public List<int>? WwtsId { get; set; } = new();


    }
}