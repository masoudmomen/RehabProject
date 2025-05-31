using Rehab.Domain.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Accreditations
{
    public class Accreditation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Facility>? Facilities { get; set; }
    }
}
