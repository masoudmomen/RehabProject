using Rehab.Application.Facilities;

namespace Rehab.EndPoint.AdminPanel.Viewmodels
{
    public class SetFacilityImagesViewmodel
    {
        public int FacilityId { get; set; }
        public string Logo { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public List<FacilityImagesViewmodel>? FacilityImages { get; set; }
    }

    public class FacilityImagesViewmodel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageAddress { get; set; } = string.Empty;
    }
}
