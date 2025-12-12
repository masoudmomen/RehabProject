namespace Rehab.EndPoint.Web.Data
{
    public class USState
    {
        public string Name { get; set; }
        public string UrlSlug => Name.ToLower().Replace(" ", "-");
        public string Image { get; set; }
   
    }

    public static class USStates
    {
        public static readonly List<USState> All = new List<USState>()
        {
            new USState { Name = "Alabama", Image = "Alabama.jpeg" },
            new USState { Name = "Alaska", Image = "Alaska.jpg" },
            new USState { Name = "Arizona", Image = "arizona.jpg" },
            new USState { Name = "Arkansas", Image = "Arkansas.jpg" },
            new USState { Name = "California", Image = "california.jpg" },
            new USState { Name = "Colorado", Image = "Colorado.jpg" },
            new USState { Name = "Connecticut", Image = "Connecticut.jpeg" },
            new USState { Name = "Delaware", Image = "Delaware.JPG" },
            new USState { Name = "Florida", Image = "Florida.jpg" },
            new USState { Name = "Georgia", Image = "Georgia.jpeg" },
            new USState { Name = "Hawaii", Image = "Hawaii.jpeg" },
            new USState { Name = "Idaho", Image = "idaho.jpg" },
            new USState { Name = "Illinois", Image = "Illinois.jpg" },
            new USState { Name = "Indiana", Image = "Indianapolis.jpeg" },
            new USState { Name = "Iowa", Image = "iowa.jpg" },
            new USState { Name = "Kansas", Image = "Kansas,_USA.jpg" },
            new USState { Name = "Kentucky", Image = "Kentucky.jpeg" },
            new USState { Name = "Louisiana", Image = "Louisiana.jpg" },
            new USState { Name = "Maine", Image = "Maine.jpeg" },
            new USState { Name = "Maryland", Image = "Maryland.jpeg" },
            new USState { Name = "Massachusetts", Image = "Massachusetts.jpeg" },
            new USState { Name = "Michigan", Image = "michigan.jpg" },
            new USState { Name = "Minnesota", Image = "minnesota.jpg" },
            new USState { Name = "Mississippi", Image = "Mississippi.jpg" },
            new USState { Name = "Missouri", Image = "Missouri.jpg" },
            new USState { Name = "Montana", Image = "montana.jpg" },
            new USState { Name = "Nebraska", Image = "nebraska.jpg" },
            new USState { Name = "Nevada", Image = "Nevada.jpg" },
            new USState { Name = "New Hampshire", Image = "New Hampshire.jpeg" },
            new USState { Name = "New Jersey", Image = "New-Jersey.jpeg" },
            new USState { Name = "New Mexico", Image = "newmexico.jpg" },
            new USState { Name = "New York", Image = "New York (state).jpg" },
            new USState { Name = "North Carolina", Image = "North Carolina.jpeg" },
            new USState { Name = "North Dakota", Image = "North_Dakota.JPG" },
            new USState { Name = "Ohio", Image = "ohio.jpeg" },
            new USState { Name = "Oklahoma", Image = "oklahoma.jpg" },
            new USState { Name = "Oregon", Image = "Oregon.jpg" },
            new USState { Name = "Pennsylvania", Image = "Pennsylvania.jpeg" },
            new USState { Name = "Rhode Island", Image = "Rhode Island.jpeg" },
            new USState { Name = "South Carolina", Image = "South Carolina.jpeg" },
            new USState { Name = "South Dakota", Image = "South Dakota.jpg" },
            new USState { Name = "Tennessee", Image = "Tennessee.jpeg" },
            new USState { Name = "Texas", Image = "no-image.jpg" },
            new USState { Name = "Utah", Image = "utah.jpg" },
            new USState { Name = "Vermont", Image = "vermont.jpeg" },
            new USState { Name = "Virginia", Image = "Virginia.jpeg" },
            new USState { Name = "Washington", Image = "washington.jpg" },
            new USState { Name = "West Virginia", Image = "West Virginia.jpg" },
            new USState { Name = "Wisconsin", Image = "Wisconsin.jpg" },
            new USState { Name = "Wyoming", Image = "wyoming-rehab.jpg" }

        };
    };

}
