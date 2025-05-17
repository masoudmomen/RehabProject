using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.AdminPanel.Viewmodels
{
    public class InsuranceViewmodel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Fill Insurance Name")]
        [Display(Name ="Name")]
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
