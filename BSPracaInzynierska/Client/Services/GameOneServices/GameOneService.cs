using BSPracaInzynierska.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.AccessControl;

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
        public List<string> availableAnswers { get; set; } = new List<string>();
        public List<string> currentAnswers { get; set; } = new List<string>();
        public List<GameAnswers> listOfTimes { get; set; } = new List<GameAnswers>();
        public MusicPlaylist rankedPlaylist { get; set; } = new MusicPlaylist();
        public double totalPoints { get; set; } = 0;
        public async Task GetSongs(Guid id, int songToGuess)
        {
            var result = await _httpClient.GetAsync($"api/Songs/{id}");
            Random rand = new Random();
            songs.Clear();
            availableAnswers.Clear();
            if (result != null)
            {
                List<Song> allSongs = await result.Content.ReadFromJsonAsync<List<Song>>();
                songs = allSongs.Take(songToGuess).ToList();
                allSongs.ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers = availableAnswers.OrderBy(a => rand.Next()).ToList();
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
                songs = rankedPlaylist.Songs.Take(rankedPlaylist.lightningRoundSongs).ToList();
                rankedPlaylist.Songs.ToList().ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers.Sort((x, y) => string.Compare(x, y));
            }

        }

        public async Task GetAnswers(string correctAnswer)
        {
            currentAnswers.Clear();
            Random rand = new Random();
            availableAnswers.ForEach(a =>
            {
                if (a != correctAnswer)
                    currentAnswers.Add(a);
            });
            availableAnswers = availableAnswers.OrderBy(a => rand.Next()).ToList();
            currentAnswers = currentAnswers.Take(3).ToList();
            currentAnswers.Add(correctAnswer);
            currentAnswers = currentAnswers.OrderBy(a => rand.Next()).ToList();
        }

        public async Task SaveToLeaderBoard(Guid userId, Guid playlistId)
        {
            LeaderBoard newLeaderBoardEntry = new LeaderBoard() { UserId = userId, PlaylistId = playlistId, Points = totalPoints, gameType = "lightningRound" };
            var resultPlaylist = await _httpClient.PutAsJsonAsync<LeaderBoard>($"api/MusicPlaylists/leaderBoard/{playlistId}", newLeaderBoardEntry);
        }
    }
}
