using BSPracaInzynierska.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services
{
    public class MainPageService : IMainPageService
    {
        private readonly HttpClient _httpClient;
        public MainPageService(HttpClient httpClient) { 
            _httpClient = httpClient;
        }
        public List<MusicPlaylist> playlists { get; set; } = new List<MusicPlaylist>();

        public async Task DeletePlaylists(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/MusicPlaylists/{id}");
        }

        public async Task GetPlaylists()
        {
            var result = await _httpClient.GetAsync("api/MusicPlaylists");

            if(result != null)
            {
                playlists = await result.Content.ReadFromJsonAsync<List<MusicPlaylist>>();
                var gsd = "dfgd";
            }
        }
    }
}
