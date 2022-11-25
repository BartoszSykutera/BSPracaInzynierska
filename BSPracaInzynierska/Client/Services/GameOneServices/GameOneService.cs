using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3.Data;
using System.Net.Http;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services.GameOneServices
{
    public class GameOneService : IGameOneService
    {
        private readonly HttpClient _httpClient;
        public GameOneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Song> songs { get; set; } = new List<Song>();

        public async Task GetSongs(Guid id)
        {
            var result = await _httpClient.GetAsync($"api/Songs/{id}");

            if (result != null)
            {
                songs = await result.Content.ReadFromJsonAsync<List<Song>>();
                var gsd = "dfgd";
            }
        }
    }
}
