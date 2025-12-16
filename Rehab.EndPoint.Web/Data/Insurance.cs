namespace Rehab.EndPoint.Web.Data
{
    public class Insurance
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class Insurances
    {
        public static readonly List<Insurance> All = new List<Insurance>()
        {
            new Insurance { Name = "Aetna", Image = "aetna.png" },
            new Insurance { Name = "Bright Health", Image = "bcbs.png" },
            new Insurance { Name = "Cigna", Image = "cigna.png" },
            new Insurance { Name = "Humana", Image = "humana.png" },
            new Insurance { Name = "Medicare", Image = "Medicare.png" },
            new Insurance { Name = "Medicaid", Image = "Medicaid.png" },
            new Insurance { Name = "United Healthcare", Image = "UnitedHealthCare.png" },

        };
    }
}
