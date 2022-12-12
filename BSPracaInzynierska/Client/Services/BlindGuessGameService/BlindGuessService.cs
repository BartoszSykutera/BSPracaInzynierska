using BSPracaInzynierska.Shared;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services.BlindGuessGameService
{
    public class BlindGuessService : IBlindGuessService
    {
        private readonly HttpClient _httpClient;
        public BlindGuessService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Song> songs { get; set; } = new List<Song>();
        public List<string> availableAnswers { get; set; } = new List<string>();
        public MusicPlaylist rankedPlaylist { get; set; } = new MusicPlaylist();
        public int badAnswers { get; set; } = 0;
        public int correctAnswers { get; set; } = 0;
        public int score { get; set; } = 0;
        public async Task GetSongs(Guid id, int songToGuess)
        {
            var result = await _httpClient.GetAsync($"api/Songs/{id}");
            songs.Clear();
            availableAnswers.Clear();
            Random rand = new Random();
            if (result != null)
            {
                List<Song> allSongs = await result.Content.ReadFromJsonAsync<List<Song>>();
                songs = allSongs.Take(songToGuess).ToList();
                allSongs.ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers.Sort((x, y) => string.Compare(x, y));
                var jfhj = "wqeq";
            }
        }

        public async Task GetRankedGame(Guid id)
        {
            var resultPlaylist = await _httpClient.GetAsync($"api/MusicPlaylists/{id}");
            Random rand = new Random();
            songs.Clear();
            availableAnswers.Clear();
            if (resultPlaylist != null)
            {
                rankedPlaylist = await resultPlaylist.Content.ReadFromJsonAsync<MusicPlaylist>();
                songs = rankedPlaylist.Songs.Take(rankedPlaylist.blindGuessSongs).ToList();
                rankedPlaylist.Songs.ToList().ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers.Sort((x, y) => string.Compare(x, y));
                var hgdfgh = "tryj";
            }

        }

        public async Task EndGame(int elapsedTime)
        {
            score += elapsedTime;
            score += correctAnswers * 100;
        }

        public async Task SaveToLeaderBoard(Guid userId, Guid playlistId)
        {
            LeaderBoard newLeaderBoardEntry = new LeaderBoard() { UserId = userId, PlaylistId = playlistId, Points = score, gameType = "blindGuess" };
            //rankedPlaylist.NumberOfTracks = songs.Count();
            //rankedPlaylist.Songs = songs;
            var resultPlaylist = await _httpClient.PutAsJsonAsync<LeaderBoard>($"api/MusicPlaylists/leaderBoard/{playlistId}", newLeaderBoardEntry);
        }
    }
}
