using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.GameCreatorService
{
    public interface IGameCreatorService
    {
        MusicPlaylist playlist { get; set; }
        List<Song> songs { get; set; }
        List<LeaderBoard> blindGuessLeaderBoard { get; set; }
        List<LeaderBoard> lightningRoundLeaderBoard { get; set; }
        MultiGame game {  get; set; }
        public Task GetSongs(Guid id);
        public Task CreateMultiGame(Guid id, int gameDuration, int songToGuess, Guid userId);
        public Task AddToFavourites(Guid userId);
        public Task RemoveFromFavourites(Guid userId);
        public Task<bool> CheckFavourites(Guid playlistId, Guid currentUserId);
    }
}
