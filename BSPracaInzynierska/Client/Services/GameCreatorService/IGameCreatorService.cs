using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.GameCreatorService
{
    public interface IGameCreatorService
    {
        MusicPlaylist playlist { get; set; }
        List<Song> songs { get; set; }
        GameTypeOne game {  get; set; }
        public Task GetSongs(Guid id);
    }
}
