using BSPracaInzynierska.Shared;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services.GameCreatorService
{
    public class GameCreatorService : IGameCreatorService
    {
        HttpClient _httpClient;
        public GameCreatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Song> songs { get; set; } = new List<Song>();
        public MusicPlaylist playlist { get; set; } = new MusicPlaylist();
        public GameTypeOne game { get; set; } = new GameTypeOne();

        public async Task GetSongs(Guid id)
        {
            var resultPlaylist = await _httpClient.GetAsync($"api/MusicPlaylists/{id}");

            if (resultPlaylist != null)
            {
                playlist = await resultPlaylist.Content.ReadFromJsonAsync<MusicPlaylist>();
                songs = playlist.Songs.ToList();
            }
        }
    }
}
