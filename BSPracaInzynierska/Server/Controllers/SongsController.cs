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

        [HttpPost("getvideobyurl")]
        public async Task<ActionResult<Song>> GetVideoByURL([FromBody] string input)
        {
            List<Song> searchedVideo = new List<Song>();
            var videoRequest = youTubeService.Videos.List("snippet");
            videoRequest.Id = input;
            videoRequest.MaxResults = 1;
            var videoResponse = await videoRequest.ExecuteAsync();
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
            if(titleParts.Count == 1)
            {
                titleParts.Insert(0, channelName);
            }
            return titleParts;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
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

        [HttpPost("postallsongs")]
        public async Task<ActionResult> PostAllSongs(List<Song> song)
        {
            _context.Songs.AddRange(song);
            await _context.SaveChangesAsync();
            var sdfg = "sdfg";

            return Ok();
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
