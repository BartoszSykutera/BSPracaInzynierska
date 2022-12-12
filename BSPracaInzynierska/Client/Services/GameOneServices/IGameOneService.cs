using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.GameOneServices
{
    public interface IGameOneService
    {
        List<Song> songs { get; set; }
        List<string> availableAnswers { get; set; }
        List<string> currentAnswers { get; set; }
        MusicPlaylist rankedPlaylist { get; set; }
        List<GameAnswers> listOfTimes { get; set; }
        double totalPoints { get; set; }
        public Task GetSongs(Guid id, int songToGuess);
        public Task GetAnswers(string correctAnswer);
        public Task GetRankedGame(Guid id);
        public Task SaveToLeaderBoard(Guid userId, Guid playlistId);
    }
}
