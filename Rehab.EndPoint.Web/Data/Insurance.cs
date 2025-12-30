namespace Rehab.EndPoint.Web.Data
{
    public class Insurance
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class Insurances
    {
        public static readonly List<Insurance> All = new List<Insurance>()
        {
            new Insurance { Name = "Aetna", Icon = "aetna.png" },
            new Insurance { Name = "Bright Health", Icon = "bcbs.png" },
            new Insurance { Name = "Cigna", Icon = "cigna.png" },
            new Insurance { Name = "Humana", Icon = "humana.png" },
            new Insurance { Name = "Medicare", Icon = "Medicare.png" },
            new Insurance { Name = "Medicaid", Icon = "Medicaid.png" },
            new Insurance { Name = "United Healthcare", Icon = "UnitedHealthCare.png" },

        };
    }
}
