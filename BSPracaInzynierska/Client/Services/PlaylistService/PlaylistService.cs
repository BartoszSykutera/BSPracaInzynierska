using BSPracaInzynierska.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
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

        public string errMess { get; set; }

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
            string pattern = @"^https:\/\/www\.youtube\.com\/watch\?.*v=([a-zA-Z0-9_\-]+)$";

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                id = match.Groups[1].Value;
                var result = await _httpClient.PostAsJsonAsync<string>("api/Songs/getvideobyurl", id);
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Song? searchedSong = await result.Content.ReadFromJsonAsync<Song>();
                    if(searchedSong != null)
                    {
                        songs.Insert(0, searchedSong);
                        musicPlaylist.blindGuessSongs = songs.Count();
                        musicPlaylist.lightningRoundSongs = songs.Count();
                    }
                }
                else
                {
                    errMess = await result.Content.ReadAsStringAsync();
                }
                
            }
        }

        public async Task GetVideosFromPlaylist(string input)
        {
            string id = "";

            string pattern = @"^https:\/\/www\.youtube\.com\/watch\?.*list=([a-zA-Z0-9_\-]+)$";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                id = match.Groups[1].Value;
                var result = await _httpClient.PostAsJsonAsync<string>("api/Songs/getplaylistbyurl", id);
                List<Song>? searchedSongs = await result.Content.ReadFromJsonAsync<List<Song>>();
                if (searchedSongs.Count() > 0)
                {
                    searchedSongs.ForEach(s =>
                    {
                        songs.Insert(0, s);
                        musicPlaylist.blindGuessSongs = songs.Count();
                        musicPlaylist.lightningRoundSongs = songs.Count();
                    });
                }
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
                musicPlaylist.blindGuessSongs = songs.Count();
                musicPlaylist.lightningRoundSongs = songs.Count();
            }
        }
        public void DeleteSongFromPlaylist(string videoId)
        {
            Song? selectedSong = null;
            selectedSong = songs.Where(v => v.YTVidoeId == videoId).FirstOrDefault();
            if (selectedSong != null)
            {
                songs.Remove(selectedSong);
                musicPlaylist.blindGuessSongs = songs.Count();
                musicPlaylist.lightningRoundSongs = songs.Count();
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
