using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.GameOneServices
{
    public interface IGameOneService
    {
        List<Song> songs { get; set; }
        List<string> availableAnswers { get; set; }
        int badAnswers { get; set; }
        int correctAnswers { get; set; }
        public Task GetSongs(Guid id);
        public Task EndGame(int elapsedTime);
    }
}
