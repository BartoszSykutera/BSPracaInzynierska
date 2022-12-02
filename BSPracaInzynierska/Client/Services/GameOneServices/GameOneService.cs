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
        public List<string> availableAnswers { get; set; } = new List<string>();
        public List<string> currentAnswers { get; set; } = new List<string>();
        public List<GameAnswers> listOfTimes { get; set; } = new List<GameAnswers>();
        public double totalPoints { get; set; } = 0;
        public async Task GetSongs(Guid id, int songToGuess, string gameGuess)
        {
            var result = await _httpClient.GetAsync($"api/Songs/{id}");
            Random rand = new Random();
            if (result != null)
            {
                List<Song> allSongs = await result.Content.ReadFromJsonAsync<List<Song>>();
                songs = allSongs.Take(songToGuess).ToList();
                allSongs.ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers = availableAnswers.OrderBy(a => rand.Next()).ToList();
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
    }
}
