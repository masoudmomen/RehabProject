using System.Net.Http.Json;
using System.Text.Json.Serialization;
using static Rehab.EndPoint.AdminPanel.CommonService.StateData;


namespace Rehab.EndPoint.AdminPanel.CommonService
{
    public class LocationService
    {
        private readonly HttpClient _http;

        public LocationService(HttpClient http)
        {
            _http = http;
        }

        //public async Task<List<string>?> GetStatesAsync()
        //{
        //    var response = await _http.PostAsJsonAsync(
        //        "https://countriesnow.space/api/v0.1/countries/states",
        //        new { country = "United States" });

        //    var result = await response.Content.ReadFromJsonAsync<StateResponse>();
        //    return result?.Data?.States.Select(c => c.Name).ToList();
        //}


        public async Task<List<State>> GetStatesAsync(string country)
        {
            var url = "https://countriesnow.space/api/v0.1/countries/states";
            var requestBody = new { country = country };

            var response = await _http.PostAsJsonAsync(url, requestBody);
            if (!response.IsSuccessStatusCode) return [];

            var result = await response.Content.ReadFromJsonAsync<CountryStatesResponse>();
            return result?.Data?.States ?? [];
        }




        public async Task<List<string>> GetCitiesAsync(string state)
        {
            var response = await _http.PostAsJsonAsync(
                "https://countriesnow.space/api/v0.1/countries/state/cities",
                new { country = "United States", state });

            var result = await response.Content.ReadFromJsonAsync<CityResponse>();
            return result?.Data ?? new();
        }
    }





    public class CountryStatesResponse
    {
        public bool Error { get; set; }
        public string Msg { get; set; }
        public CountryData Data { get; set; }
    }

    public class CountryData
    {
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public List<State> States { get; set; }
    }

    public class State
    {
        public string Name { get; set; }
        public string State_Code { get; set; }
    }












    //مدل های داخلی پاسخ

    public class StateResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        [JsonPropertyName("data")]
        public StateData Data { get; set; }
    }
    public class StateData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iso3")]
        public string Iso3 { get; set; }

        [JsonPropertyName("states")]
        public List<StateData> States { get; set; }

        public class StateInfo
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("state_code")]
            public string StateCode { get; set; }
        }

        public class CityResponse
        {
            public List<string>? Data { get; set; }
        }

    }
}
