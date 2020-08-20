using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServer.Web.Data
{
    public class PlaceService
    {
        private readonly HttpClient _httpClient;
        private HubConnection _hubConnection;
        public PlaceService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }
        public string NewPlaceName { get; set; }
        public int NewPlaceId { get; set; }
        public event Action OnChange;

        public async Task InitializeSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
               .WithUrl($"{_httpClient.BaseAddress.AbsoluteUri}PlaceApiHub")
               .Build();

            _hubConnection.On<int, string>("NotifyNewPlaceAdded", (placeId, placeName) =>
            {
                UpdateUIState(placeId, placeName);
            });

            await _hubConnection.StartAsync();
        }

        public void UpdateUIState(int placeId, string placeName)
        {
            NewPlaceId = placeId;
            NewPlaceName = placeName;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task<IEnumerable<Place>> GetPlacesAsync()
        {
            var response = await _httpClient.GetAsync("/api/places");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var jsonOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<IEnumerable<Place>>(json, jsonOption);

            return data;
        }

        public async Task UpdatePlaceAsync(Place place)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/places", place);
            response.EnsureSuccessStatusCode();
        }
    }
}

