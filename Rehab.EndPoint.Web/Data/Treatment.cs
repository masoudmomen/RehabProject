namespace Rehab.EndPoint.Web.Data
{
    public class Treatment
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class Treatments
    {
        public static readonly List<Treatment> All = new List<Treatment>()
        {
            new Treatment { Name = "1-on-1 Counseling", Image = "therapy.png" },
            new Treatment { Name = "Acceptance and Commitment Therapy (ACT)", Image = "ACT.png" },
            new Treatment { Name = "Acupuncture", Image = "acupuncture.png" },
            new Treatment { Name = "Adult-Child Therapy", Image = "adult-child.png" },
            new Treatment { Name = "Adventure Therapy", Image = "adventure.png" },
            new Treatment { Name = "Art Therapy", Image = "art-therapy.png" },
            new Treatment { Name = "Cognitive Behavioral Therapy", Image = "CBT.png" },
            new Treatment { Name = "Couples Counseling", Image = "couple-counseling.png" },
      
            new Treatment { Name = "Massage Therapy", Image = "massage.png" },
           
            new Treatment { Name = "Medication-Assisted Treatment", Image = "med.png" },
            new Treatment { Name = "Meditation & Mindfulness", Image = "yoga.png" },
            
            new Treatment { Name = "Motivational Interviewing", Image = "support.png" },
            new Treatment { Name = "Reiki", Image = "energy.png" }
 
        };
    }
}
