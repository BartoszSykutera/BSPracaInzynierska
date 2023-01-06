using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSPracaInzynierska.Server.DB;
using BSPracaInzynierska.Shared;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace BSPracaInzynierska.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly YouTubeService youTubeService;

        public SongsController(DataContext context, YouTubeService youTubeService)
        {
            _context = context;
            this.youTubeService = youTubeService;
        }

        [HttpPost("getplaylistbyurl")]
        public async Task<ActionResult<List<Song>>> GetPlaylistByURL([FromBody] string input)
        {
            List<Song> searchedVideo = new List<Song>();
            string nextPageToken = "";
            do
            {
                var playlistRequest = youTubeService.PlaylistItems.List("snippet");
                playlistRequest.PlaylistId = input;
                if (nextPageToken != "")
                    playlistRequest.PageToken = nextPageToken;
                var playlistResponse = await playlistRequest.ExecuteAsync();
                searchedVideo.AddRange(playlistResponse.Items.Select(video => new Song
                    {
                        Author = CreateTitleAuthor(video.Snippet.Title, video.Snippet.ChannelTitle)[0],
                        Title = CreateTitleAuthor(video.Snippet.Title, video.Snippet.ChannelTitle)[1],
                        Picture = video.Snippet.Thumbnails.Medium.Url,
                        YTVideoTitle = video.Snippet.Title,
                        YTVidoeId = video.Snippet.ResourceId.VideoId,
                        YTChanelName = video.Snippet.ChannelTitle
                    }));
                nextPageToken = playlistResponse.NextPageToken;

            } while (nextPageToken != null);

            return Ok(searchedVideo);
        }

        [HttpPost("getvideobyurl")]
        public async Task<ActionResult<Song>> GetVideoByURL([FromBody] string input)
        {
            List<Song> searchedVideo = new List<Song>();
            var videoRequest = youTubeService.Videos.List("snippet");
            videoRequest.Id = input;
            videoRequest.MaxResults = 1;
            var videoResponse = await videoRequest.ExecuteAsync();
            if (videoResponse.Items.Count > 0 || videoResponse.Items.First().Snippet.CategoryId=="10")
            {
                searchedVideo.AddRange(videoResponse.Items.Select(video => new Song
                {
                    Author = CreateTitleAuthor(video.Snippet.Title, video.Snippet.ChannelTitle)[0],
                    Title = CreateTitleAuthor(video.Snippet.Title, video.Snippet.ChannelTitle)[1],
                    Picture = video.Snippet.Thumbnails.Medium.Url,
                    YTVideoTitle = video.Snippet.Title,
                    YTVidoeId = video.Id,
                    YTChanelName = video.Snippet.ChannelTitle
                }));
                return Ok(searchedVideo.First());
            }
            return BadRequest("Given URL is not a song");
        }

        [HttpPost("getvideos")]
        public async Task<ActionResult<List<Song>>> GetVideos([FromBody] string input)
        {
            List<Song> searchedVideos = new List<Song>();
            var searchListRequest = youTubeService.Search.List("snippet");
            searchListRequest.Q = input;
            searchListRequest.MaxResults = 5;
            searchListRequest.Type = "video";
            searchListRequest.VideoCategoryId = "10";
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            var searchListResponse = await searchListRequest.ExecuteAsync();
            searchedVideos.AddRange(searchListResponse.Items.Select(video => new Song
            {
                Author = CreateTitleAuthor(video.Snippet.Title, video.Snippet.ChannelTitle)[0].Trim(),
                Title = CreateTitleAuthor(video.Snippet.Title, video.Snippet.ChannelTitle)[1].Trim(),
                Picture = video.Snippet.Thumbnails.Medium.Url,
                YTVideoTitle = video.Snippet.Title,
                YTVidoeId = video.Id.VideoId,
                YTChanelName = video.Snippet.ChannelTitle
            }));


            return Ok(searchedVideos);
        }

        private List<string> CreateTitleAuthor(string YTVideoTitle, string channelName)
        {
            List<string> titleParts = YTVideoTitle.Split('-', 2).ToList();
            if (titleParts.Count == 1)
            {
                titleParts.Insert(0, channelName);
            }
            return titleParts;
        }

        // GET: api/Songs
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs(Guid id)
        {
            MusicPlaylist playlist = await _context.MusicPlaylists.Include(p => p.Songs).Where(p => p.Id == id).FirstOrDefaultAsync();
            if (playlist == null)
            {
                return NotFound();
            }
            return playlist.Songs.ToList();
        }


        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(Guid id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("postsong")]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(Guid id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
