using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3.Data;
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
        public List<LeaderBoard> blindGuessLeaderBoard { get; set; } = new List<LeaderBoard>();
        public List<LeaderBoard> lightningRoundLeaderBoard { get; set; } = new List<LeaderBoard>();
        public MultiGame game { get; set; } = new MultiGame();

        public async Task CreateMultiGame(Guid id, int gameDuration, int songToGuess, Guid userId)
        {
            game.PlaylistId = id;
            game.gameTime = gameDuration;
            game.NumberOfTracks = songToGuess;
            game.UserHost = userId;
            var resultGame = await _httpClient.PostAsJsonAsync<MultiGame>("api/MultiGames", game);
        }

        public async Task AddToFavourites(Guid userId)
        {
            playlist.favourites++;
            var addToFav = await _httpClient.PutAsJsonAsync<MusicPlaylist>($"api/MusicPlaylists/addFav/{userId}/{playlist.Id}", playlist);
        }

        public async Task RemoveFromFavourites(Guid userId)
        {
            playlist.favourites--;
            var addToFav = await _httpClient.PutAsJsonAsync<MusicPlaylist>($"api/MusicPlaylists/delFav/{userId}/{playlist.Id}", playlist);
        }

        public async Task<bool> CheckFavourites(Guid playlistId, Guid currentUserId)
        {
            var resultStatus = await _httpClient.GetAsync($"api/MusicPlaylists/favStatus/{playlistId}/{currentUserId}");
            var resultStatusCode = resultStatus.StatusCode;
            if(resultStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
            
        }

        public async Task GetSongs(Guid id)
        {
            //playlist = null;
            playlist = new MusicPlaylist();
            var resultPlaylist = await _httpClient.GetAsync($"api/MusicPlaylists/{id}");

            if (resultPlaylist != null)
            {
                playlist = await resultPlaylist.Content.ReadFromJsonAsync<MusicPlaylist>();
                //var resulat = await _httpClient.PostAsJsonAsync<MusicPlaylist>("api/MusicPlaylists", playlist);
                songs = playlist.Songs.ToList();
                blindGuessLeaderBoard = playlist.LeaderBoards.Where(l => l.gameType == "blindGuess").OrderByDescending(l => l.Points).ToList();
                lightningRoundLeaderBoard = playlist.LeaderBoards.Where(l => l.gameType == "lightningRound").OrderByDescending(l => l.Points).ToList();
            }
        }
    }
}
