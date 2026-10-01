namespace Rehab.EndPoint.Web.Data
{
    public class Amenitiescs
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }
    }
    public class Amenities
    {
        public static readonly List<Amenitiescs> All = new List<Amenitiescs>()
        {
            new Amenitiescs { Name = "Private Rooms", Order = 1, Icon = "" },
            new Amenitiescs { Name = "Private or Shared Rooms", Order = 2 },
            new Amenitiescs { Name = "Transportation Assistance", Order = 3 },
            new Amenitiescs { Name = "Airport Transfers", Order = 4 },
            new Amenitiescs { Name = "Allow Cell Phones", Order = 5 },
            new Amenitiescs { Name = "Internet Access", Order = 6, Icon = "" },
            new Amenitiescs { Name = "Childcare Support", Order = 7, Icon = "" },
            new Amenitiescs { Name = "Fitness Center", Order = 8, Icon = "" },
            new Amenitiescs { Name = "Wellness Center", Order = 9 },
            new Amenitiescs { Name = "Access to Nature", Order = 10, Icon = "" },
            new Amenitiescs { Name = "Outdoor Space", Order = 11 },
            new Amenitiescs { Name = "Walking Trails", Order = 12 },
            new Amenitiescs { Name = "Pool / Swimming", Order = 13, Icon = "" },
            new Amenitiescs { Name = "Chef-Prepared Meals", Order = 14 },
            new Amenitiescs { Name = "Laundry Service", Order = 15 },
            new Amenitiescs { Name = "Business Center", Order = 16, Icon = "" }
         };
    }
}
