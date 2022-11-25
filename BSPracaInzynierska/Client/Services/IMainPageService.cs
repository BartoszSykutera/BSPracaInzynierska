using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3.Data;

namespace BSPracaInzynierska.Client.Services
{
    interface IMainPageService
    {
        List<MusicPlaylist> playlists { get; set; }
        public Task GetPlaylists();
        public Task DeletePlaylists(Guid id);
    }
}
