namespace Rehab.EndPoint.Web.Data
{
    public class LevelOfCare
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class LevelOfCareList
    {
        public static List<LevelOfCare> All = new List<LevelOfCare>
        {
            new LevelOfCare { Name = "Concierge Treatment", Image = "concierge_treatment.png" },
            new LevelOfCare { Name = "Co-Occurring Disorders", Image = "co_occurring_disorders.png" },
            new LevelOfCare { Name = "Co-Occurring Mental Health", Image = "co_occurring_mental_health.png" },
            new LevelOfCare { Name = "Co-Occurring Substance Use", Image = "co_occurring_substance_use.png" },
            new LevelOfCare { Name = "Day Treatment", Image = "concierge_treatment.png" },
            new LevelOfCare { Name = "Detox", Image = "detox.png" },
            new LevelOfCare { Name = "In-Home", Image = "in_home.png" },
            new LevelOfCare { Name = "Intensive Family Program", Image = "intensive_family_program.png" },
            new LevelOfCare { Name = "Intensive Inpatient", Image = "intensive_inpatient.png" },
            new LevelOfCare { Name = "Intensive Outpatient Program", Image = "co_occurring_substance_use.png" },
            new LevelOfCare { Name = "Interventionists", Image = "detox.png" },
            new LevelOfCare { Name = "Licensed Primary Mental Health", Image = "concierge_treatment.png" },
            new LevelOfCare { Name = "Outpatient", Image = "co_occurring_substance_use.png" },
            new LevelOfCare { Name = "Outpatient Therapy", Image = "co_occurring_disorders.png" }
        };
    }
}
