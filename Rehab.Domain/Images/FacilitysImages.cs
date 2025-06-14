using Rehab.Domain.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Images
{
    public class FacilitysImages
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageAddress { get; set; } = string.Empty;
        public Facility? Facility { get; set; }
    }
}
