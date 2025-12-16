namespace Rehab.EndPoint.Web.Data
{
    public class wwt
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public static class WWTList
    {
        public static readonly List<wwt> All = new()
        {
            new wwt { Name = "Adolescents", Image = "Adolescents.png" },
            new wwt { Name = "Boys", Image = "Boys.png" },
            new wwt { Name = "Children", Image = "Children.png" },
            new wwt { Name = "Couples", Image = "Couple.png" },
            new wwt { Name = "Executives", Image = "Couple.png" },
            new wwt { Name = "Girls", Image = "Girls.png" },
            new wwt { Name = "LGBTQ+", Image = "LGBTQ.png" },
            new wwt { Name = "Men", Image = "Men.png" },
            new wwt { Name = "Pregnant Women", Image = "Pregnant-women.png" },
            new wwt { Name = "Women", Image = "Women.png" },
            new wwt { Name = "Veterans", Image = "Veterans.png  " },
            new wwt { Name = "Older Adults", Image = "Older-Adults.png" },
        };
    }
}
