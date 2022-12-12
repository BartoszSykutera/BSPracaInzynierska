using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.BlindGuessGameService
{
    public interface IBlindGuessService
    {
        List<Song> songs { get; set; }
        List<string> availableAnswers { get; set; }
        MusicPlaylist rankedPlaylist { get; set; }
        int badAnswers { get; set; }
        int correctAnswers { get; set; }
        int score { get; set; }
        public Task GetSongs(Guid id, int songToGuess);
        public Task GetRankedGame(Guid id);
        public Task EndGame(int elapsedTime);
        public Task SaveToLeaderBoard(Guid userId, Guid playlistId);
    }
}
