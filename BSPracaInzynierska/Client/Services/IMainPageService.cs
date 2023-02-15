using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Client.Services
{
    interface IMainPageService
    {
        List<MusicPlaylist> allPlaylists { get; set; }
        List<MusicPlaylist> shownPlaylists { get; set; }
        public Task GetPlaylists();
        public Task DeletePlaylists(Guid id);
        public Task CheckboxClick(bool isChecked);
        public Task ChangeFilter(string filter);
        public Task<HttpResponseMessage> JoinGame(string gameCode, Guid playerId);
    }
}
