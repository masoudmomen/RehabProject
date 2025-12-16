namespace Rehab.EndPoint.Web.Data
{
    public class Amenitiescs
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class Amenities
    {
        public static readonly List<Amenitiescs> All = new List<Amenitiescs>()
        {
            new Amenitiescs { Name = "Access to Nature", Image = "Nature.png" },
            new Amenitiescs { Name = "Basketball Court", Image = "court.png" },
            new Amenitiescs { Name = "Business Center", Image = "bc.png" },
            new Amenitiescs { Name = "Childcare for Clients Children", Image = "childcare.png" },
            new Amenitiescs { Name = "Fitness Center", Image = "fitness.png" },
            new Amenitiescs { Name = "Gardens", Image = "park.png" },
            new Amenitiescs { Name = "Internet Access", Image = "internet.png" },
            new Amenitiescs { Name = "Library", Image = "library.png" },
            new Amenitiescs { Name = "Physical Therapy Center", Image = "physical-therapy.png" },
            new Amenitiescs { Name = "Private Rooms", Image = "PVRoom.png" },
            new Amenitiescs { Name = "Spa", Image = "spa.png" },
            new Amenitiescs { Name = "Swimming", Image = "swimming-pool.png" },
            
         };
    }
}
