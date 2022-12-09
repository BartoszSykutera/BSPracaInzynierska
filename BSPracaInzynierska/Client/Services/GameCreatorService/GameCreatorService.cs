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
        public MultiGame game { get; set; } = new MultiGame();

        public async Task CreateMultiGame(Guid id, int gameDuration, int songToGuess, Guid userId)
        {
            //songs.ForEach(s => s.PlaylistId = musicPlaylist.Id);
            //musicPlaylist.UserId = id;
            //musicPlaylist.NumberOfTracks = songs.Count();
            //musicPlaylist.Songs = songs;
            game.PlaylistId = id;
            //game.Playlist = playlist;
            game.gameTime = gameDuration;
            game.NumberOfTracks = songToGuess;
            game.UserHost = userId;
            var resultGame = await _httpClient.PostAsJsonAsync<MultiGame>("api/MultiGames", game);
        }

        public async Task GetSongs(Guid id)
        {
            var resultPlaylist = await _httpClient.GetAsync($"api/MusicPlaylists/{id}");

            

            if (resultPlaylist != null)
            {
                playlist = await resultPlaylist.Content.ReadFromJsonAsync<MusicPlaylist>();
                //var resulat = await _httpClient.PostAsJsonAsync<MusicPlaylist>("api/MusicPlaylists", playlist);
                songs = playlist.Songs.ToList();
            }
        }
    }
}
