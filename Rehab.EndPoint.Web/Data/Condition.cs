namespace Rehab.EndPoint.Web.Data
{
    public class Condition
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public string? Image { get; set; }
    }
    public class Conditions
    {

       public static readonly List<Condition> All = new List<Condition>()
        {
            new Condition { Name = "ADHD, ADD", Icon = "adhd.png" },
            new Condition { Name = "Anger", Icon = "angry.png" },
            new Condition { Name = "Anxiety", Icon = "Anxiety.png" },
            new Condition { Name = "Bipolar", Icon = "bipolar.png" },
            new Condition { Name = "Burnout", Icon = "burnout.png" },
            new Condition { Name = "Depression", Icon = "depression.png" },
            new Condition { Name = "Eating Disorders", Icon = "EatingDisorder.png" },
            new Condition { Name = "Grief and Loss", Icon = "MentalDisorder.png" },
            new Condition { Name = "Internet Addiction", Icon = "internet-addiction.png" },
            new Condition { Name = "Narcissism", Icon = "MentalDisorder.png" },
            new Condition { Name = "Neurodiversity", Icon = "MentalDisorder.png" },
            new Condition { Name = "Obsessive Compulsive Disorder (OCD)", Icon = "MentalDisorder.png" },
            new Condition { Name = "Perinatal Mental Health", Icon = "MentalDisorder.png" },
            new Condition { Name = "Personality Disorders", Icon = "MentalDisorder.png" },
            new Condition { Name = "Pornography Addiction", Icon = "MentalDisorder.png" },
            new Condition { Name = "Post Traumatic Stress Disorder", Icon = "MentalDisorder.png" },
            new Condition { Name = "Schizophrenia", Icon = "MentalDisorder.png" },
            new Condition { Name = "Self-Harm", Icon = "MentalDisorder.png" },
            new Condition { Name = "Sex Addiction", Icon = "MentalDisorder.png" },
            new Condition { Name = "Shopping Addiction", Icon = "MentalDisorder.png" },
            new Condition { Name = "Stress", Icon = "stress.png" },
            new Condition { Name = "Suicidality", Icon = "MentalDisorder.png" },
            new Condition { Name = "Trauma", Icon = "trauma.png" }
        };
    }

}