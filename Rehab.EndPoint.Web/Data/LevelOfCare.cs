namespace Rehab.EndPoint.Web.Data
{
    public class LevelOfCare
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public int Order { get; set; }
    }

    public class LevelOfCareList
    {
        public static List<LevelOfCare> All = new List<LevelOfCare>
        {
            new LevelOfCare { Name = "Detox / Withdrawal Management", Order = 1, Image = "", Description = "24/7 medical" },
            new LevelOfCare { Name = "Residential Treatment", Order = 2, Image = "", Description = "Live-in · 24/7" },
            new LevelOfCare { Name = "Intensive Inpatient Treatment", Order = 3, Image = "", Description = "Hospital-level care" },
            new LevelOfCare { Name = "Day Treatment / Partial Hospitalization Program (PHP)", Order = 4, Image = "", Description = "Structured full days" },
            new LevelOfCare { Name = "Intensive Outpatient Program (IOP)", Order = 5, Image = "", Description = "A few days a week" },
            new LevelOfCare { Name = "Outpatient Treatment", Order = 6, Image = "", Description = "Flexible schedule" },
            new LevelOfCare { Name = "Virtual Treatment", Order = 7, Image = "", Description = "Online sessions" },
            new LevelOfCare { Name = "Sober Living / Recovery Housing", Order = 8, Image = "", Description = "Supportive housing" },
            new LevelOfCare { Name = "Co-Occurring Disorder Treatment", Order = 9, Image = "", Description = "Dual diagnosis" },
            new LevelOfCare { Name = "Primary Mental Health Treatment", Order = 10, Image = "", Description = "Mental health first" },
            new LevelOfCare { Name = "Concierge Treatment", Order = 11, Image = "", Description = "Private & tailored" },
            new LevelOfCare { Name = "Co-Occurring Mental Health Treatment", Order = 12, Image = "", Description = "Mental health focus" },
            new LevelOfCare { Name = "Co-Occurring Substance Use Treatment", Order = 13, Image = "", Description = "Substance use focus" },
            new LevelOfCare { Name = "In-Home Treatment", Order = 14, Image = "", Description = "Care at home" },
            new LevelOfCare { Name = "Intensive Family Program", Order = 15, Image = "", Description = "Family-centered" },
            new LevelOfCare { Name = "Interventionists", Order = 16, Image = "", Description = "Guided intervention" },
            new LevelOfCare { Name = "Outpatient Therapy", Order = 17, Image = "", Description = "Regular sessions" },
            new LevelOfCare { Name = "Private Therapy", Order = 18, Image = "", Description = "1-on-1 sessions" },
            new LevelOfCare { Name = "Recovery Coaching", Order = 19, Image = "", Description = "Ongoing guidance" },
            new LevelOfCare { Name = "Recovery School", Order = 20, Image = "", Description = "Education + recovery" },
            new LevelOfCare { Name = "Retreat Programs", Order = 21, Image = "", Description = "Short-term immersive" },
            new LevelOfCare { Name = "Sober Companion", Order = 22, Image = "", Description = "1-on-1 daily support" },
            new LevelOfCare { Name = "Therapeutic Boarding School", Order = 23, Image = "", Description = "Adolescents · live-in" }
        };
    }
}
