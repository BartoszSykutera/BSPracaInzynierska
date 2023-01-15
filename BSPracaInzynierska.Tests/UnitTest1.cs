using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using BSPracaInzynierska.Server.Controllers;
using System.Drawing.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BSPracaInzynierska.Server.DB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BSPracaInzynierska.Shared;
using System.Net.Http.Json;
using System.Security.Cryptography;

namespace BSPracaInzynierska.Tests
{    public class UnitTest1:IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private HttpClient client;
        public UnitTest1(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            client = _factory.CreateClient();
        }
        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private void CreateTestData(out User user, out MusicPlaylist playlist, out List<Song> songs)
        {
            CreatePasswordHash("testPassword", out byte[] hash, out byte[] salt);
            user = new User
            {
                Username = "TestUser",
                Email = "testEmail",
                PasswordSalt = salt,
                PasswordHash = hash
            };
            playlist = new MusicPlaylist
            {
                PlaylistName = "TestPlaylist",
                Description = "TestDescription",
                UserId = user.Id,
                Creator = user
            };
            songs = new List<Song>();
            songs.AddRange(new List<Song>
            {
                new Song
                {
                    Title = "TestTitle",
                    Author = "TestAuthor",
                    Picture = "TestPicture",
                    PlaylistId = playlist.Id,
                    YTChanelName = "TestName",
                    YTVideoTitle = "TestVidTitle",
                    YTVidoeId = "TestVidId"
                },
                new Song
                {
                    Title = "TestTitle2",
                    Author = "TestAuthor2",
                    Picture = "TestPicture2",
                    PlaylistId = playlist.Id,
                    YTChanelName = "TestName2",
                    YTVideoTitle = "TestVidTitle2",
                    YTVidoeId = "TestVidId2"
                }
            });
            playlist.Songs = songs;
            user.MusicPlaylists = new List<MusicPlaylist>();
            user.MusicPlaylists.Add(playlist);
        }

        [Fact]
        public async Task PostANewPlaylistAsNewUser_Successful()
        { 
            CreateTestData(out User user, out MusicPlaylist playlist, out List<Song> songs);
            UserLogs userLogs = new UserLogs { Password = "TestPassword", Username = user.Username };
            var postUser = await client.PostAsJsonAsync<UserLogs>("api/Auth/register", userLogs);
            postUser.EnsureSuccessStatusCode();
            Assert.NotNull(postUser);

            var result = await postUser.Content.ReadAsStringAsync();
            Guid newUserId = new Guid(result);
            playlist.UserId = newUserId;
            
            var postPlaylist = await client.PostAsJsonAsync<MusicPlaylist>("api/MusicPlaylists", playlist);
            postPlaylist.EnsureSuccessStatusCode();
            var responsePlaylist = await client.GetAsync($"api/MusicPlaylists/{playlist.Id}");
            responsePlaylist.EnsureSuccessStatusCode();

            Assert.NotNull(responsePlaylist);
            MusicPlaylist retrievedPlaylist = await responsePlaylist.Content.ReadFromJsonAsync<MusicPlaylist>();
            Assert.NotNull(retrievedPlaylist);
            Assert.Equal(playlist.Id, retrievedPlaylist.Id);
            Assert.Equal(playlist.UserId, retrievedPlaylist.UserId);
            Assert.Equal(playlist.Songs.Count, retrievedPlaylist.Songs.Count);
            Assert.True(playlist.Songs.Contains(songs[0]));
            Assert.True(playlist.Songs.Contains(songs[1]));
        }
    }
}

