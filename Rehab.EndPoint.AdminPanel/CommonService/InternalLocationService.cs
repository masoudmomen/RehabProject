namespace Rehab.EndPoint.AdminPanel.CommonService
{
    using Microsoft.AspNetCore.Components;
    using System.Text.Json;
    using static Microsoft.AspNetCore.Components.NavigationManager;

    public class InternalLocationService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager NavigationManager;
        public InternalLocationService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            NavigationManager = navigationManager;
        }
        public async Task<List<StateModel>> GetStatesAndCitiesAsync()
        {
            var data = await _http.GetFromJsonAsync<List<StateModel>>(NavigationManager.BaseUri + "Data/states-and-cities.json");
            return data ?? new List<StateModel>();
        }

        public async Task<List<string>> GetStatesAsync()
        {
            var data = await _http.GetFromJsonAsync<List<StateOnlyModel>>(NavigationManager.BaseUri + "Data/states.json");
            return data?.Select(s => s.Name!).ToList() ?? new List<string>();
        }

        public async Task<List<string>> GetCitiesByStateAsync(string stateName)
        {
            var all = await GetStatesAndCitiesAsync();
            var item = all.FirstOrDefault(x => x.State == stateName);
            return item?.Cities?.ToList() ?? new List<string>();
        }
    }

    public class StateModel
    {
        public string? State { get; set; }
        public string[]? Cities { get; set; }
    }
    public class StateOnlyModel
    {
        public string? Name { get; set; }
        public string? Abbreviation { get; set; }
    }

}
