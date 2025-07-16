using Rehab.Domain.Amenities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Tags
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Amenity>? Amenities { get; set; }
    }
}
