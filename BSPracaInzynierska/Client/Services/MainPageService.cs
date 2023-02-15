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
        public List<MusicPlaylist> allPlaylists { get; set; } = new List<MusicPlaylist>();
        public List<MusicPlaylist> shownPlaylists { get; set; } = new List<MusicPlaylist>();


        public async Task<HttpResponseMessage> JoinGame(string gameCode, Guid playerId)
        {
            var response = await _httpClient.GetAsync($"api/MultiGames/gameCode/{gameCode}/{playerId}");
            var responseStatusCode = response.StatusCode;
            var returnedMessage = await response.Content.ReadAsStringAsync();
            return response;
        }

        public async Task CheckboxClick(bool isChecked)
        {
            if(isChecked == true)
            {
                shownPlaylists = allPlaylists.FindAll(p => p.Creator.Role == "Admin");
            }
            else
            {
                shownPlaylists = allPlaylists;
            }
            
        }

        public async Task ChangeFilter(string filter)
        {
            if(filter == "date")
            {
                allPlaylists = allPlaylists.OrderByDescending(p => p.CreationDate).ToList();
                shownPlaylists = shownPlaylists.OrderByDescending(p => p.CreationDate).ToList();
            }
            else
            {
                allPlaylists = allPlaylists.OrderByDescending(p => p.favourites).ToList();
                shownPlaylists = shownPlaylists.OrderByDescending(p => p.favourites).ToList();
            }
        }

        public async Task DeletePlaylists(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/MusicPlaylists/{id}");
            MusicPlaylist playlistToRemove = allPlaylists.Where(p => p.Id == id).FirstOrDefault();
            allPlaylists.Remove(playlistToRemove);
            shownPlaylists?.Remove(playlistToRemove);
        }

        public async Task GetPlaylists()
        {
            var result = await _httpClient.GetAsync("api/MusicPlaylists");

            if(result != null)
            {
                allPlaylists = await result.Content.ReadFromJsonAsync<List<MusicPlaylist>>();
                shownPlaylists = allPlaylists.OrderByDescending(p => p.CreationDate).ToList();
            }
        }
    }
}
