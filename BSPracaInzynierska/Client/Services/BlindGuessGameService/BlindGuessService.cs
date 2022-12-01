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
        public int badAnswers { get; set; } = 0;
        public int correctAnswers { get; set; } = 0;
        public int score { get; set; } = 0;
        public async Task GetSongs(Guid id, int songToGuess, string gameGuess)
        {
            var result = await _httpClient.GetAsync($"api/Songs/{id}");
            Random rand = new Random();
            if (result != null)
            {
                List<Song> allSongs = await result.Content.ReadFromJsonAsync<List<Song>>();
                songs = allSongs.Take(songToGuess).ToList();
                if(gameGuess == "Author")
                    songs.ForEach(s => availableAnswers.Add(s.Author));
                else if(gameGuess == "Title")
                    songs.ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers = availableAnswers.OrderBy(a => rand.Next()).ToList();
            }
        }

        public async Task EndGame(int elapsedTime)
        {
            score += elapsedTime;
            score += correctAnswers * 100;
        }
    }
}
