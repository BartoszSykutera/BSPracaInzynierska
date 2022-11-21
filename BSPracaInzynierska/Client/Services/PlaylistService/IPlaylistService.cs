using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services.PlaylistService
{
    public interface IPlaylistService
    {
        List<Song> songs { get; set; }
        List<Song> searchedVideos { get; set; }
        MusicPlaylist musicPlaylist { get; set; }
        public Task CreatePlaylist(Guid id);
        public Task GetVideos(string input);
        public Task GetVideo(string input);
        public void AddSongToPlaylist(string id);
        public void DeleteSongFromPlaylist(string id);
    }
}
