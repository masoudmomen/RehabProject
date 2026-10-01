namespace Rehab.EndPoint.Web.Data
{
    public class USState
    {
        public string Name { get; set; }
        public string UrlSlug => Name.ToLower().Replace(" ", "-");
        public string Image { get; set; }
        public string Abbreviation { get; set; }
        // US Census region: Northeast, Midwest, South or West
        public string Region { get; set; }
        // Approximate geographic centre, used to find the nearest state to the visitor
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public static class USStates
    {
        public static readonly List<USState> All = new List<USState>()
        {
            new USState { Name = "Alabama", Abbreviation = "AL", Region = "South", Image = "Alabama.jpeg", Latitude = 32.8, Longitude = -86.8 },
            new USState { Name = "Alaska", Abbreviation = "AK", Region = "West", Image = "Alaska.jpg", Latitude = 64.2, Longitude = -152.5 },
            new USState { Name = "Arizona", Abbreviation = "AZ", Region = "West", Image = "arizona.jpg", Latitude = 34.3, Longitude = -111.7 },
            new USState { Name = "Arkansas", Abbreviation = "AR", Region = "South", Image = "Arkansas.jpg", Latitude = 34.9, Longitude = -92.4 },
            new USState { Name = "California", Abbreviation = "CA", Region = "West", Image = "california.jpg", Latitude = 37.2, Longitude = -119.5 },
            new USState { Name = "Colorado", Abbreviation = "CO", Region = "West", Image = "Colorado.jpg", Latitude = 39.0, Longitude = -105.5 },
            new USState { Name = "Connecticut", Abbreviation = "CT", Region = "Northeast", Image = "Connecticut.jpeg", Latitude = 41.6, Longitude = -72.7 },
            new USState { Name = "Delaware", Abbreviation = "DE", Region = "South", Image = "Delaware.JPG", Latitude = 39.0, Longitude = -75.5 },
            new USState { Name = "Florida", Abbreviation = "FL", Region = "South", Image = "Florida.jpg", Latitude = 28.6, Longitude = -82.4 },
            new USState { Name = "Georgia", Abbreviation = "GA", Region = "South", Image = "Georgia.jpeg", Latitude = 32.7, Longitude = -83.4 },
            new USState { Name = "Hawaii", Abbreviation = "HI", Region = "West", Image = "Hawaii.jpeg", Latitude = 20.8, Longitude = -156.3 },
            new USState { Name = "Idaho", Abbreviation = "ID", Region = "West", Image = "idaho.jpg", Latitude = 44.4, Longitude = -114.6 },
            new USState { Name = "Illinois", Abbreviation = "IL", Region = "Midwest", Image = "Illinois.jpg", Latitude = 40.0, Longitude = -89.2 },
            new USState { Name = "Indiana", Abbreviation = "IN", Region = "Midwest", Image = "Indianapolis.jpeg", Latitude = 39.9, Longitude = -86.3 },
            new USState { Name = "Iowa", Abbreviation = "IA", Region = "Midwest", Image = "iowa.jpg", Latitude = 42.1, Longitude = -93.5 },
            new USState { Name = "Kansas", Abbreviation = "KS", Region = "Midwest", Image = "Kansas,_USA.jpg", Latitude = 38.5, Longitude = -98.4 },
            new USState { Name = "Kentucky", Abbreviation = "KY", Region = "South", Image = "Kentucky.jpeg", Latitude = 37.5, Longitude = -85.3 },
            new USState { Name = "Louisiana", Abbreviation = "LA", Region = "South", Image = "Louisiana.jpg", Latitude = 31.1, Longitude = -92.0 },
            new USState { Name = "Maine", Abbreviation = "ME", Region = "Northeast", Image = "Maine.jpeg", Latitude = 45.4, Longitude = -69.2 },
            new USState { Name = "Maryland", Abbreviation = "MD", Region = "South", Image = "Maryland.jpeg", Latitude = 39.0, Longitude = -76.8 },
            new USState { Name = "Massachusetts", Abbreviation = "MA", Region = "Northeast", Image = "Massachusetts.jpeg", Latitude = 42.3, Longitude = -71.8 },
            new USState { Name = "Michigan", Abbreviation = "MI", Region = "Midwest", Image = "michigan.jpg", Latitude = 44.3, Longitude = -85.4 },
            new USState { Name = "Minnesota", Abbreviation = "MN", Region = "Midwest", Image = "minnesota.jpg", Latitude = 46.3, Longitude = -94.3 },
            new USState { Name = "Mississippi", Abbreviation = "MS", Region = "South", Image = "Mississippi.jpg", Latitude = 32.7, Longitude = -89.7 },
            new USState { Name = "Missouri", Abbreviation = "MO", Region = "Midwest", Image = "Missouri.jpg", Latitude = 38.4, Longitude = -92.5 },
            new USState { Name = "Montana", Abbreviation = "MT", Region = "West", Image = "montana.jpg", Latitude = 47.0, Longitude = -109.6 },
            new USState { Name = "Nebraska", Abbreviation = "NE", Region = "Midwest", Image = "nebraska.jpg", Latitude = 41.5, Longitude = -99.8 },
            new USState { Name = "Nevada", Abbreviation = "NV", Region = "West", Image = "Nevada.jpg", Latitude = 39.3, Longitude = -116.6 },
            new USState { Name = "New Hampshire", Abbreviation = "NH", Region = "Northeast", Image = "New Hampshire.jpeg", Latitude = 43.7, Longitude = -71.6 },
            new USState { Name = "New Jersey", Abbreviation = "NJ", Region = "Northeast", Image = "New-Jersey.jpeg", Latitude = 40.2, Longitude = -74.7 },
            new USState { Name = "New Mexico", Abbreviation = "NM", Region = "West", Image = "newmexico.jpg", Latitude = 34.4, Longitude = -106.1 },
            new USState { Name = "New York", Abbreviation = "NY", Region = "Northeast", Image = "New York (state).jpg", Latitude = 42.9, Longitude = -75.5 },
            new USState { Name = "North Carolina", Abbreviation = "NC", Region = "South", Image = "North Carolina.jpeg", Latitude = 35.6, Longitude = -79.4 },
            new USState { Name = "North Dakota", Abbreviation = "ND", Region = "Midwest", Image = "North_Dakota.JPG", Latitude = 47.5, Longitude = -100.5 },
            new USState { Name = "Ohio", Abbreviation = "OH", Region = "Midwest", Image = "ohio.jpeg", Latitude = 40.3, Longitude = -82.8 },
            new USState { Name = "Oklahoma", Abbreviation = "OK", Region = "South", Image = "oklahoma.jpg", Latitude = 35.6, Longitude = -97.5 },
            new USState { Name = "Oregon", Abbreviation = "OR", Region = "West", Image = "Oregon.jpg", Latitude = 43.9, Longitude = -120.6 },
            new USState { Name = "Pennsylvania", Abbreviation = "PA", Region = "Northeast", Image = "Pennsylvania.jpeg", Latitude = 40.9, Longitude = -77.8 },
            new USState { Name = "Rhode Island", Abbreviation = "RI", Region = "Northeast", Image = "Rhode Island.jpeg", Latitude = 41.7, Longitude = -71.5 },
            new USState { Name = "South Carolina", Abbreviation = "SC", Region = "South", Image = "South Carolina.jpeg", Latitude = 33.9, Longitude = -80.9 },
            new USState { Name = "South Dakota", Abbreviation = "SD", Region = "Midwest", Image = "South Dakota.jpg", Latitude = 44.4, Longitude = -100.2 },
            new USState { Name = "Tennessee", Abbreviation = "TN", Region = "South", Image = "Tennessee.jpeg", Latitude = 35.9, Longitude = -86.4 },
            new USState { Name = "Texas", Abbreviation = "TX", Region = "South", Image = "no-image.jpg", Latitude = 31.5, Longitude = -99.3 },
            new USState { Name = "Utah", Abbreviation = "UT", Region = "West", Image = "utah.jpg", Latitude = 39.3, Longitude = -111.7 },
            new USState { Name = "Vermont", Abbreviation = "VT", Region = "Northeast", Image = "vermont.jpeg", Latitude = 44.1, Longitude = -72.7 },
            new USState { Name = "Virginia", Abbreviation = "VA", Region = "South", Image = "Virginia.jpeg", Latitude = 37.5, Longitude = -78.9 },
            new USState { Name = "Washington", Abbreviation = "WA", Region = "West", Image = "washington.jpg", Latitude = 47.4, Longitude = -120.5 },
            new USState { Name = "West Virginia", Abbreviation = "WV", Region = "South", Image = "West Virginia.jpg", Latitude = 38.6, Longitude = -80.6 },
            new USState { Name = "Wisconsin", Abbreviation = "WI", Region = "Midwest", Image = "Wisconsin.jpg", Latitude = 44.6, Longitude = -89.9 },
            new USState { Name = "Wyoming", Abbreviation = "WY", Region = "West", Image = "wyoming-rehab.jpg", Latitude = 43.0, Longitude = -107.6 }

        };
    };

}
