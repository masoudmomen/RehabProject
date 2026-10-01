namespace Rehab.EndPoint.Web.Data
{
    public class Condition
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; } = "Depression is a mood disorder marked by a persistent low mood and reduced interest or pleasure in daily activities. It is one of the leading causes of disability globally and affects people across all age groups. Common experiences include low energy, changes in sleep or appetite, difficulty concentrating, and emotional numbness, with symptoms often interacting with anxiety, trauma, and chronic stress.";
        public bool IsMostCommon { get; set; } = false;
        public int Order { get; set; }
    }
    public class Conditions
    {

       public static readonly List<Condition> All = new List<Condition>()
        {
            new Condition { Name = "Anxiety", Order = 1, Image = "" },
            new Condition { Name = "Depression", Order = 2, Image = "" },
            new Condition { Name = "Trauma", Order = 3, Image = "" },
            new Condition { Name = "Post-Traumatic Stress Disorder (PTSD)", Order = 4, Image = "" },
            new Condition { Name = "Co-Occurring Disorders", Order = 5, Image = "" },
            new Condition { Name = "Bipolar Disorder", Order = 6, Image = "" },
            new Condition { Name = "ADHD / ADD", Order = 7, Image = "" },
            new Condition { Name = "Obsessive Compulsive Disorder (OCD)", Order = 8, Image = "" },
            new Condition { Name = "Eating Disorders", Order = 9, Image = "" },
            new Condition { Name = "Self-Harm", Order = 10, Image = "" },
            new Condition { Name = "Suicidality", Order = 11, Image = "" },
            new Condition { Name = "Schizophrenia", Order = 12, Image = "" },
            new Condition { Name = "Personality Disorders", Order = 13, Image = "" },
            new Condition { Name = "Chronic Pain Management", Order = 14, Image = "" },
            new Condition { Name = "Gambling", Order = 15, Image = "" },
            new Condition { Name = "Anger", Order = 16, Image = "" },
            new Condition { Name = "Burnout", Order = 17, Image = "" },
            new Condition { Name = "Codependency", Order = 18, Image = "" },
            new Condition { Name = "Gaming", Order = 19, Image = "" },
            new Condition { Name = "Internet Addiction", Order = 20, Image = "" },
            new Condition { Name = "Narcissism", Order = 21, Image = "" },
            new Condition { Name = "Neurodiversity", Order = 22, Image = "" },
            new Condition { Name = "Perinatal Mental Health", Order = 23, Image = "" },
            new Condition { Name = "Pornography Addiction", Order = 24, Image = "" },
            new Condition { Name = "Sex Addiction", Order = 25, Image = "" },
            new Condition { Name = "Shopping Addiction", Order = 26, Image = "" },
            new Condition { Name = "Stress", Order = 27, Image = "" },
            new Condition { Name = "Grief and Loss", Order = 28, Image = "" }
        };
    }

}