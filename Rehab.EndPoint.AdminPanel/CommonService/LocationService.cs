using System.Net.Http.Json;


namespace Rehab.EndPoint.AdminPanel.CommonService
{
    public class LocationService
    {
        private readonly HttpClient _http;

        public LocationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<string>> GetStatesAsync()
        {
            var response = await _http.PostAsJsonAsync(
                "https://countriesnow.space/api/v0.1/countries/states",
                new { country = "United States" });

            var result = await response.Content.ReadFromJsonAsync<StateResponse>();
            return result?.Data?.States.Select(s => s.Name).ToList() ?? new();
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


    //مدل های داخلی پاسخ

    public class StateResponse
    {
        public StateData? Data { get; set; }
    }
    public class StateData
    {
        public List<StateInfo> States { get; set; } = new();
    }

    public class StateInfo
    {
        public string Name { get; set; } = "";
    }

    public class CityResponse
    {
        public List<string>? Data { get; set; }
    }

}
