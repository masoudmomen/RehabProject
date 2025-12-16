namespace Rehab.EndPoint.Web.Data
{
    public class Condition
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class Conditions
    {

       public static readonly List<Condition> All = new List<Condition>()
        {
            new Condition { Name = "ADHD, ADD", Image = "adhd.png" },
            new Condition { Name = "Anger", Image = "angry.png" },
            new Condition { Name = "Anxiety", Image = "Anxiety.png" },
            new Condition { Name = "Bipolar", Image = "bipolar.png" },
            new Condition { Name = "Burnout", Image = "burnout.png" },
            new Condition { Name = "Depression", Image = "depression.png" },
            new Condition { Name = "Eating Disorders", Image = "EatingDisorder.png" },
            new Condition { Name = "Grief and Loss", Image = "MentalDisorder.png" },
            new Condition { Name = "Internet Addiction", Image = "internet-addiction.png" },
            new Condition { Name = "Narcissism", Image = "MentalDisorder.png" },
            new Condition { Name = "Neurodiversity", Image = "MentalDisorder.png" },
            new Condition { Name = "Obsessive Compulsive Disorder (OCD)", Image = "MentalDisorder.png" },
            new Condition { Name = "Perinatal Mental Health", Image = "MentalDisorder.png" },
            new Condition { Name = "Personality Disorders", Image = "MentalDisorder.png" },
            new Condition { Name = "Pornography Addiction", Image = "MentalDisorder.png" },
            new Condition { Name = "Post Traumatic Stress Disorder", Image = "MentalDisorder.png" },
            new Condition { Name = "Schizophrenia", Image = "MentalDisorder.png" },
            new Condition { Name = "Self-Harm", Image = "MentalDisorder.png" },
            new Condition { Name = "Sex Addiction", Image = "MentalDisorder.png" },
            new Condition { Name = "Shopping Addiction", Image = "MentalDisorder.png" },
            new Condition { Name = "Stress", Image = "stress.png" },
            new Condition { Name = "Suicidality", Image = "MentalDisorder.png" },
            new Condition { Name = "Trauma", Image = "trauma.png" }
        };
    }

}