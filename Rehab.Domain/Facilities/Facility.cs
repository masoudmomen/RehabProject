using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Rehab.Domain.Insurances;

namespace Rehab.Domain.Facilities
{
    public class Facility
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
        public bool IsVerified { get; set; } = false;
        public short Founded { get; set; }
        public short OccupancyMin { get; set; } 
        public short OccupancyMax { get; set; } 
        public ICollection<Insurance>? Insurances { get; set; }

    }
}
