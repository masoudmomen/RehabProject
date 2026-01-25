namespace Rehab.EndPoint.Web.Data
{
    public class Condition
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; } = "Depression is a mood disorder marked by a persistent low mood and reduced interest or pleasure in daily activities. It is one of the leading causes of disability globally and affects people across all age groups. Common experiences include low energy, changes in sleep or appetite, difficulty concentrating, and emotional numbness, with symptoms often interacting with anxiety, trauma, and chronic stress.";
        public bool IsMostCommon { get; set; } = false;
    }
    public class Conditions
    {

       public static readonly List<Condition> All = new List<Condition>()
        {
            new Condition { Name = "ADHD, ADD", Icon = "adhd.png" ,IsMostCommon=true, Description="ADHD is a neurodevelopmental condition that affects attention, impulse control, and executive functioning. Although commonly identified in childhood, it frequently continues into adulthood and can influence organization, focus, and emotional regulation. ADHD exists in different presentations and often overlaps with anxiety, mood conditions, and learning differences." },
            new Condition { Name = "Anger", Icon = "angry.png" },
            new Condition { Name = "Bipolar", Icon = "bipolar.png" ,IsMostCommon=true ,Description="Depression is a mood disorder marked by a persistent low mood and reduced interest or pleasure in daily activities. It is one of the leading causes of disability globally and affects people across all age groups. Common experiences include low energy, changes in sleep or appetite, difficulty concentrating, and emotional numbness, with symptoms often interacting with anxiety, trauma, and chronic stress."  },
            new Condition { Name = "Burnout", Icon = "burnout.png" },
            new Condition { Name = "Depression", Icon = "depression.png" ,IsMostCommon=true ,Description="Depression is a mood disorder marked by a persistent low mood and reduced interest or pleasure in daily activities. It is one of the leading causes of disability globally and affects people across all age groups. Common experiences include low energy, changes in sleep or appetite, difficulty concentrating, and emotional numbness, with symptoms often interacting with anxiety, trauma, and chronic stress." },
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
            new Condition { Name = "Stress", Icon = "stress.png", IsMostCommon=true , Description="Stress refers to the body’s natural response to perceived demands or pressures and is a nearly universal human experience. While stress itself is not always a clinical diagnosis, prolonged or chronic stress is associated with emotional strain, physical tension, sleep disruption, and cognitive fatigue. Stress plays a central role in the development and worsening of many mental health conditions, including anxiety and depression."},
            new Condition { Name = "Suicidality", Icon = "MentalDisorder.png" },
            new Condition { Name = "Trauma", Icon = "trauma.png" }
        };
    }

}