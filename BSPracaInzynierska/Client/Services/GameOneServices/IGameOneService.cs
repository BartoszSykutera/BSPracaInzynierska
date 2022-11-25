using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.GameOneServices
{
    public interface IGameOneService
    {
        List<Song> songs { get; set; }
        public Task GetSongs(Guid id);
    }
}
