namespace Rehab.EndPoint.Web.Data
{
    public class Treatment
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }

        public string? Description { get; set; }
        public int Order { get; set; }
    }

    public class Treatments
    {
        public static readonly List<Treatment> All = new List<Treatment>()
        {
            new Treatment { Name = "Medication-Assisted Treatment (MAT)", Order = 1, Icon = "", Image = "" },
            new Treatment { Name = "Contingency Management (CM)", Order = 2, Icon = "", Image = "" },
            new Treatment { Name = "Cognitive Behavioral Therapy (CBT)", Order = 3, Icon = "", Image = "" },
            new Treatment { Name = "Motivational Interviewing (MI)", Order = 4, Icon = "", Image = "" },
            new Treatment {
                Name = "1-on-1 Counseling",
                Order = 5,
                Icon = "" ,
                Image = "" ,
                Description="A private, one-to-one therapy session focused on understanding personal challenges, improving emotional well-being, and developing healthy coping strategies."},
            new Treatment { Name = "Group Therapy", Order = 6, Icon = "", Image = "" },
            new Treatment { Name = "Family Therapy", Order = 7, Icon = "", Image = "" },
            new Treatment { Name = "Relapse Prevention Counseling", Order = 8, Icon = "", Image = "" },
            new Treatment { Name = "Trauma-Specific Therapy", Order = 9, Icon = "", Image = "" },
            new Treatment { Name = "Dialectical Behavior Therapy (DBT)", Order = 10, Icon = "", Image = "" },
            new Treatment { Name = "EMDR Therapy", Order = 11, Icon = "", Image = "" },
            new Treatment { Name = "Twelve Step Facilitation (TSF)", Order = 12, Icon = "", Image = "" },
            new Treatment { Name = "Psychoeducation / Didactic Group Therapy", Order = 13, Icon = "", Image = "" },
            new Treatment { Name = "Meditation & Mindfulness", Order = 14, Icon = "", Image = "" },
            new Treatment { Name = "Life Skills", Order = 15, Icon = "", Image = "" }

        };
    }
}
