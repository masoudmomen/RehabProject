namespace Rehab.EndPoint.Web.Data
{
    public class AgeGroup
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Order { get; set; }
    }

    public class AgeGroupList
    {
        public static readonly List<AgeGroup> All = new List<AgeGroup>
        {
            new AgeGroup { Name = "Adolescents / Teens", Order = 1, Image = "" },
            new AgeGroup { Name = "Young Adults", Order = 2 },
            new AgeGroup { Name = "Adults", Order = 3 },
            new AgeGroup { Name = "Older Adults", Order = 4, Image = "" },
            new AgeGroup { Name = "Women", Order = 5, Image = "" },
            new AgeGroup { Name = "Men", Order = 6, Image = "" },
            new AgeGroup { Name = "LGBTQ+", Order = 7, Image = "" },
            new AgeGroup { Name = "Veterans", Order = 8, Image = "" },
            new AgeGroup { Name = "Pregnant & Parenting Women", Order = 9, Image = "" },
            new AgeGroup { Name = "Professionals & Executives", Order = 10 },
            new AgeGroup { Name = "Couples", Order = 11, Image = "" },
            new AgeGroup { Name = "Neurodivergent", Order = 12, Image = "" }
        };
    }
}
