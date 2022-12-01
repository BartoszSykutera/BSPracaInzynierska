using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.BlindGuessGameService
{
    public interface IBlindGuessService
    {
        List<Song> songs { get; set; }
        List<string> availableAnswers { get; set; }
        int badAnswers { get; set; }
        int correctAnswers { get; set; }
        int score { get; set; }
        public Task GetSongs(Guid id, int songToGuess, string gameGuess);
        public Task EndGame(int elapsedTime);
    }
}
