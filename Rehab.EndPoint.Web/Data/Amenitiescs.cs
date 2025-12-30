namespace Rehab.EndPoint.Web.Data
{
    public class Amenitiescs
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
    public class Amenities
    {
        public static readonly List<Amenitiescs> All = new List<Amenitiescs>()
        {
            new Amenitiescs { Name = "Access to Nature", Icon = "Nature.png" },
            new Amenitiescs { Name = "Basketball Court", Icon = "court.png" },
            new Amenitiescs { Name = "Business Center", Icon = "bc.png" },
            new Amenitiescs { Name = "Childcare for Clients Children", Icon = "childcare.png" },
            new Amenitiescs { Name = "Fitness Center", Icon = "fitness.png" },
            new Amenitiescs { Name = "Gardens", Icon = "park.png" },
            new Amenitiescs { Name = "Internet Access", Icon = "internet.png" },
            new Amenitiescs { Name = "Library", Icon = "library.png" },
            new Amenitiescs { Name = "Physical Therapy Center", Icon = "physical-therapy.png" },
            new Amenitiescs { Name = "Private Rooms", Icon = "PVRoom.png" },
            new Amenitiescs { Name = "Spa", Icon = "spa.png" },
            new Amenitiescs { Name = "Swimming", Icon = "swimming-pool.png" },
            
         };
    }
}
