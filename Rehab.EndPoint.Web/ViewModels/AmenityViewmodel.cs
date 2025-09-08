using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class AmenityViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<TagViewModel>? Tags { get; set; }
    }
}
