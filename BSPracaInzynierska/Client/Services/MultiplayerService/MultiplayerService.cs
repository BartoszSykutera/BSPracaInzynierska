using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3.Data;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services.MultiplayerService
{
    public class MultiplayerService : IMultiplayerService
    {

        HttpClient _httpClient;
        public MultiplayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public MultiGame MultiGame { get; set; } = new MultiGame();
        public List<Song> SongList { get; set; } = new List<Song>();
        public List<User> UserList { get; set; } = new List<User>();
        public List<string> availableAnswers { get; set; } = new List<string>();
        public List<string> currentAnswers { get; set; } = new List<string>();
        public List<InGamePlayerInfo> inGameLeaderboard { get; set; } = new List<InGamePlayerInfo>();
        public List<InGamePlayerInfo> currentListOfTimes { get; set; } = new List<InGamePlayerInfo>();
        public async Task<string> GetGame(Guid id)
        {
            var resultGame = await _httpClient.GetAsync($"api/MultiGames/{id}");
            Random rand = new Random();
            if (resultGame != null)
            {
                MultiGame = await resultGame.Content.ReadFromJsonAsync<MultiGame>();
                SongList = MultiGame.Playlist.Songs.ToList();
                SongList.ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers = availableAnswers.OrderBy(a => rand.Next()).ToList();
                return MultiGame.Id.ToString();
            }
            return "No game";
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
    }
}
