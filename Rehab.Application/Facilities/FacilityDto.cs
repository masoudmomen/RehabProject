namespace Rehab.Application.Facilities
{
    public class FacilityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int City { get; set; }
        public int State { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}