using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.ProfileServices
{
    public interface IProfileService
    {
        User userProfile { get; set; }
        List<MusicPlaylist> favouritePlaylists { get; set; }
        List<MusicPlaylist> createdPlaylists { get; set; }
        public Task GetUser(Guid id);
        public Task GetCreatedPlaylist(Guid id);
        public Task DeletePlaylists(Guid id);
    }
}
