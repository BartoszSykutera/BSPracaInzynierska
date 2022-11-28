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
        public int badAnswers { get; set; } = 0;
        public int correctAnswers { get; set; } = 0;
        public async Task GetSongs(Guid id)
        {
            var result = await _httpClient.GetAsync($"api/Songs/{id}");
            Random rand = new Random();
            if (result != null)
            {
                songs = await result.Content.ReadFromJsonAsync<List<Song>>();
                songs.ForEach(s => availableAnswers.Add(s.Title));
                availableAnswers = availableAnswers.OrderBy(a => rand.Next()).ToList();
            }
        }

        public async Task EndGame(int elapsedTime)
        {
            var sum = 0;
            sum += elapsedTime;
            if(correctAnswers>=badAnswers)
            {
                sum += correctAnswers * 100 - badAnswers * 100;
            }

            var dg = "fdgh";
            
        }
    }
}
