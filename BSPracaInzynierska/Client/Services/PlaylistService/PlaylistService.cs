using BSPracaInzynierska.Shared;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;


namespace BSPracaInzynierska.Client.Services.PlaylistService
{
    public class PlaylistService : IPlaylistService
    {
        private readonly HttpClient _httpClient;
        public PlaylistService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public List<Song> songs { get; set; } = new List<Song>();
        public List<Song> searchedVideos { get; set; } = new List<Song>();
        public MusicPlaylist musicPlaylist { get; set; } = new MusicPlaylist();

        public async Task GetPlaylist(Guid id)
        {
            var resultPlaylist = await _httpClient.GetAsync($"api/MusicPlaylists/{id}");

            if (resultPlaylist != null)
            {
                musicPlaylist = await resultPlaylist.Content.ReadFromJsonAsync<MusicPlaylist>();
                songs = musicPlaylist.Songs.ToList();
            }
        }

        public async Task GetVideo(string input)
        {
            string id = "";
            if (input.Split('/')[input.Split('/').Length - 1].Split('=').Length > 1)
            {
                id = input.Split('/')[input.Split('/').Length - 1].Split('=')[1];
            }
            else
            {
                id = input.Split('/')[input.Split('/').Length - 1];
            }

            var result = await _httpClient.PostAsJsonAsync<string>("api/Songs/getvideobyurl", id);
            Song? searchedSong = await result.Content.ReadFromJsonAsync<Song>();
            if(searchedSong != null)
            {
                songs.Insert(0, searchedSong);
            }
        }

        public async Task GetVideosFromPlaylist(string input)
        {
            string id = "";
            if (input.Split('/')[input.Split('/').Length - 1].Split('=').Length > 1)
            {
                id = input.Split('/')[input.Split('/').Length - 1].Split('=')[1];
            }
            else
            {
                id = input.Split('/')[input.Split('/').Length - 1];
            }

            var result = await _httpClient.PostAsJsonAsync<string>("api/Songs/getplaylistbyurl", id);
            Song? searchedSong = await result.Content.ReadFromJsonAsync<Song>();
            if (searchedSong != null)
            {
                songs.Insert(0, searchedSong);
            }
        }

        public async Task GetVideos(string input)
        {
            searchedVideos.Clear();
            var result = await _httpClient.PostAsJsonAsync<string>("api/Songs/getvideos", input);
            searchedVideos = await result.Content.ReadFromJsonAsync<List<Song>>();
        }

        public void AddSongToPlaylist(string videoId)
        {
            Song? selectedSong = null;
            selectedSong = searchedVideos.Where(v => v.YTVidoeId == videoId).FirstOrDefault();
            if(selectedSong != null)
            {
                songs.Insert(0, selectedSong);
                //searchedVideos.Remove(selectedSong);
            }
        }

        public void DeleteSongFromPlaylist(string videoId)
        {
            Song? selectedSong = null;
            selectedSong = songs.Where(v => v.YTVidoeId == videoId).FirstOrDefault();
            if (selectedSong != null)
            {
                songs.Remove(selectedSong);
                //searchedVideos.Add(selectedSong);
            }
        }

        public async Task CreatePlaylist(Guid id)
        {
            songs.ForEach(s => s.PlaylistId = musicPlaylist.Id);
            musicPlaylist.UserId = id;
            musicPlaylist.NumberOfTracks = songs.Count();
            musicPlaylist.Songs = songs;
            var resultPlaylist = await _httpClient.PostAsJsonAsync<MusicPlaylist>("api/MusicPlaylists", musicPlaylist);
        }

        public async Task UpdatePlaylist(Guid id)
        {
            songs.ForEach(s => s.PlaylistId = musicPlaylist.Id);
            musicPlaylist.NumberOfTracks = songs.Count();
            musicPlaylist.Songs = songs;
            var resultPlaylist = await _httpClient.PutAsJsonAsync<MusicPlaylist>($"api/MusicPlaylists/{musicPlaylist.Id}", musicPlaylist);
        }
    }
}
