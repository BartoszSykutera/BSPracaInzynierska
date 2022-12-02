using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.GameOneServices
{
    public interface IGameOneService
    {
        List<Song> songs { get; set; }
        List<string> availableAnswers { get; set; }
        List<string> currentAnswers { get; set; }
        List<GameAnswers> listOfTimes { get; set; }
        double totalPoints { get; set; }
        public Task GetSongs(Guid id, int songToGuess, string gameGuess);
        public Task GetAnswers(string correctAnswer);
    }
}
