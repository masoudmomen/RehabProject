namespace Rehab.EndPoint.Web.Data
{
    public class Insurance
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }
    }

    public class Insurances
    {
        public static readonly List<Insurance> All = new List<Insurance>()
        {
            new Insurance { Name = "Blue Cross Blue Shield", Order = 1, Icon = "01_Blue_Cross_Blue_Shield.png" },
            new Insurance { Name = "UnitedHealthcare", Order = 2, Icon = "02_UnitedHealthcare.png" },
            new Insurance { Name = "Aetna", Order = 3, Icon = "03_Aetna.png" },
            new Insurance { Name = "Cigna", Order = 4, Icon = "04_Cigna.png" },
            new Insurance { Name = "Anthem", Order = 5, Icon = "05_Anthem.png" },
            new Insurance { Name = "Kaiser Permanente", Order = 6, Icon = "06_Kaiser_Permanente.png" },
            new Insurance { Name = "Humana", Order = 7, Icon = "07_Humana.png" },
            new Insurance { Name = "Optum", Order = 8, Icon = "08_Optum.png" },
            new Insurance { Name = "Medicaid", Order = 9, Icon = "09_Medicaid.png" },
            new Insurance { Name = "Medicare", Order = 10, Icon = "10_Medicare.png" },
            new Insurance { Name = "TRICARE", Order = 11, Icon = "11_TRICARE.png" },
            new Insurance { Name = "TriWest / VA Community Care", Order = 12, Icon = "12_TriWest_VA_Community_Care.png" },
            new Insurance { Name = "Carelon Behavioral Health", Order = 13, Icon = "13_Carelon_Behavioral_Health.png" },
            new Insurance { Name = "Magellan Health", Order = 14, Icon = "14_Magellan_Health.png" },
            new Insurance { Name = "Molina Healthcare", Order = 15, Icon = "15_Molina_Healthcare.png" },
            new Insurance { Name = "Ambetter", Order = 16, Icon = "16_Ambetter.png" }
        };
    }
}
