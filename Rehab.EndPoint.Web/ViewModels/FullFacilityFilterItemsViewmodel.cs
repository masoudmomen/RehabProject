
namespace Rehab.EndPoint.Web.ViewModels
{
    public class FullFacilityFilterItemsViewmodel
    {
        public string SearchText { get; set; } = string.Empty;
        public List<string> States { get; set; } = new();
        public List<ConditionViewModel> Conditions { get; set; } = new();
        public List<TreatmentViewmodel> Treatments { get; set; } = new();
        public List<WwtViewModel> Wwts { get; set; } = new();
        public List<LocViewmodel> Locs { get; set; } = new();
        public List<InsuranceViewModel> Insurances { get; set; } = new();
        public List<AmenityViewmodel> Amenities { get; set; } = new();
        public List<SwtViewModel> Swts { get; set; } = new();
        public List<AccreditationViewmodel> Accreditations { get; set; } = new();
    }
}
