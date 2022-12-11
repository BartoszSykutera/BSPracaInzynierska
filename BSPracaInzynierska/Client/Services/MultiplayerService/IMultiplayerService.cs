using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.MultiplayerService
{
    public interface IMultiplayerService
    {
        MultiGame MultiGame { get; set; }
        List<Song> SongList { get; set; }
        List<User> UserList { get; set; }
        List<string> availableAnswers { get; set; }
        List<string> currentAnswers { get; set; }
        List<InGamePlayerInfo> inGameLeaderboard { get; set; }
        List<InGamePlayerInfo> currentListOfTimes { get; set; }
        public Task<string> GetGame(Guid id);
        public Task GetAnswers(string correctAnswer);
    }
}
