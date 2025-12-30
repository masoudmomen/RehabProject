namespace Rehab.EndPoint.Web.Data
{
    public class Treatment
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }

        public string? Description { get; set; }
    }

    public class Treatments
    {
        public static readonly List<Treatment> All = new List<Treatment>()
        {
            new Treatment { 
                Name = "1-on-1 Counseling",
                Icon = "therapy.png" ,
                Image="one-to-one.jpg" ,
                Description="A private, one-to-one therapy session focused on understanding personal challenges, improving emotional well-being, and developing healthy coping strategies."},
            new Treatment { 
                Name = "Acceptance and Commitment Therapy (ACT)",
                Icon = "ACT.png", 
                Image="Act.jpg" ,
                Description="A mindfulness-based therapy that helps individuals accept difficult thoughts and feelings while committing to actions aligned with their values." },
            new Treatment { 
                Name = "Acupuncture",
                Icon = "acupuncture.png",
                Image="Acupuncture.jpg" ,
                Description="A traditional healing practice that involves inserting fine needles into specific points on the body to promote balance, relieve pain, and support overall wellness."},
            new Treatment { 
                Name = "Adult-Child Therapy", 
                Icon = "adult-child.png", 
                Image="Adult-Child-Therapy.jpg" ,
                Description="A therapeutic approach that helps adults heal unresolved childhood experiences by strengthening self-awareness, emotional regulation, and inner-child connection."},
            new Treatment { Name = "Adventure Therapy", Icon = "adventure.png", Image="" },
            new Treatment { Name = "Art Therapy", Icon = "art-therapy.png", Image="" },
            new Treatment { Name = "Cognitive Behavioral Therapy", Icon = "CBT.png", Image="" },
            new Treatment { Name = "Couples Counseling", Icon = "couple-counseling.png", Image="" },
      
            new Treatment { Name = "Massage Therapy", Icon = "massage.png" },
           
            new Treatment { Name = "Medication-Assisted Treatment", Icon = "med.png" },
            new Treatment { Name = "Meditation & Mindfulness", Icon = "yoga.png" },
            
            new Treatment { Name = "Motivational Interviewing", Icon = "support.png" },
            new Treatment { Name = "Reiki", Icon = "energy.png" }
 
        };
    }
}
