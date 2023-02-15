using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSPracaInzynierska.Server.DB;
using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicPlaylistsController : ControllerBase
    {
        private readonly DataContext _context;

        public MusicPlaylistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MusicPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicPlaylist>>> GetMusicPlaylists()
        {
            return await _context.MusicPlaylists.Include(p => p.Songs).Include(p => p.Creator).ToListAsync();
        }

        // GET: api/MusicPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicPlaylist>> GetMusicPlaylist(Guid id)
        {
            var musicPlaylist = await _context.MusicPlaylists.Include(p => p.Songs).Include(p => p.LeaderBoards).ThenInclude(l => l.Player).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (musicPlaylist == null)
            {
                return NotFound();
            }

            return musicPlaylist;
        }

        // GET: api/MusicPlaylists/userId/5
        [HttpGet("userId/{id}")]
        public async Task<ActionResult<List<MusicPlaylist>>> GetMusicPlaylistByUserId(Guid id)
        {
            List<MusicPlaylist> musicPlaylist = await _context.MusicPlaylists.Include(p => p.Songs).Include(p => p.Creator).Where(p => p.UserId == id).ToListAsync();

            if (musicPlaylist == null)
            {
                return NotFound();
            }

            return musicPlaylist;
        }

        // GET: api/MusicPlaylists/userId/5
        [HttpGet("favStatus/{playlistId}/{currentUserId}")]
        public async Task<ActionResult> GetFavouriteStatus(Guid playlistId, Guid currentUserId)
        {
            User currUser = await _context.Uzytkownicy.Include(u => u.FavouritePlaylists).Where(u => u.Id == currentUserId).FirstOrDefaultAsync();
            MusicPlaylist musicPlaylist = currUser.FavouritePlaylists.Where(p => p.Id == playlistId).FirstOrDefault();

            if (musicPlaylist == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // PUT: api/MusicPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicPlaylist(Guid id, MusicPlaylist musicPlaylist)
        {
            var dbPlaylist = await _context.MusicPlaylists.Include(p => p.Songs).Include(p => p.Creator).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (dbPlaylist == null)
            {
                return NotFound();
            }

            List<Song> dbSongList = dbPlaylist.Songs.ToList();
            List<Song> editSongList = musicPlaylist.Songs.ToList();

            _context.MusicPlaylists.Any(e => e.Id == id);

            dbSongList.ForEach(s =>
            {
                dbPlaylist.Songs.Remove(s);
                _context.Remove(s);
            });

            editSongList.ForEach(s =>
            {
                dbPlaylist.Songs.Add(s);
                _context.Add(s);
            });

            dbPlaylist.NumberOfTracks = musicPlaylist.NumberOfTracks;
            dbPlaylist.PlaylistName = musicPlaylist.PlaylistName;
            dbPlaylist.Description = musicPlaylist.Description;

            dbPlaylist.blindGuessSongs = musicPlaylist.blindGuessSongs;
            dbPlaylist.blindGuessTime = musicPlaylist.blindGuessTime;
            dbPlaylist.lightningRoundSongs = musicPlaylist.lightningRoundSongs;
            dbPlaylist.lightningRoundTime = musicPlaylist.lightningRoundTime;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/MusicPlaylists/addFav/1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("addFav/{userId}/{id}")]
        public async Task<IActionResult> PutAddToFavourites(Guid userId, Guid id, MusicPlaylist musicPlaylist)
        {
            var dbPlaylist = await _context.MusicPlaylists.Where(p => p.Id == id).FirstOrDefaultAsync();
            User user = await _context.Uzytkownicy.Include(u => u.FavouritePlaylists).Where(u => u.Id == userId).FirstOrDefaultAsync();
            if (dbPlaylist == null || user == null)
            {
                return NotFound();
            }
            List<MusicPlaylist> list = user.FavouritePlaylists.ToList();
            dbPlaylist.favourites = musicPlaylist.favourites;
            list.Add(dbPlaylist);
            user.FavouritePlaylists = list;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/MusicPlaylists/addFav/1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("delFav/{userId}/{id}")]
        public async Task<IActionResult> PutRemoveFromFavourites(Guid userId, Guid id, MusicPlaylist musicPlaylist)
        {
            var dbPlaylist = await _context.MusicPlaylists.Where(p => p.Id == id).FirstOrDefaultAsync();
            User user = await _context.Uzytkownicy.Include(u => u.FavouritePlaylists).Where(u => u.Id == userId).FirstOrDefaultAsync();
            if (dbPlaylist == null || user == null)
            {
                return NotFound();
            }
            //List<MusicPlaylist> list = new List<MusicPlaylist>();
            dbPlaylist.favourites = musicPlaylist.favourites;
            user.FavouritePlaylists.Remove(dbPlaylist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/MusicPlaylists/leaderBoard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("leaderBoard/{playlistId}")]
        public async Task<IActionResult> PutChangeLeaderBoard(Guid playlistId, LeaderBoard newEntry)
        {
            var dbPlaylist = await _context.MusicPlaylists.Include(p => p.LeaderBoards).ThenInclude(l => l.Player).Where(p => p.Id == playlistId).FirstOrDefaultAsync();
            User user = await _context.Uzytkownicy.Where(u => u.Id == newEntry.UserId).FirstOrDefaultAsync();
            newEntry.Player = user;
            if (dbPlaylist.LeaderBoards == null)
            {
                List<LeaderBoard> boards = new List<LeaderBoard>();
                boards.Add(newEntry);
                dbPlaylist.LeaderBoards = boards;
                _context.LeaderBoard.Add(newEntry);
            }
            else
            {
                List<LeaderBoard> userResults = new List<LeaderBoard>();
                userResults = dbPlaylist.LeaderBoards.Where(e => e.UserId == newEntry.UserId).ToList();
                if (dbPlaylist.LeaderBoards.Any(e => e.UserId == newEntry.UserId))
                {
                    if (userResults.Any(u => u.gameType == newEntry.gameType))
                    {
                        dbPlaylist.LeaderBoards.ToList().ForEach(e =>
                        {
                            if (e.UserId == newEntry.UserId && e.gameType == newEntry.gameType)
                            {
                                if (e.Points < newEntry.Points)
                                    e.Points = newEntry.Points;
                            }
                        });
                    }
                    else
                    {
                        dbPlaylist.LeaderBoards.Add(newEntry);
                        _context.LeaderBoard.Add(newEntry);
                    }

                }
                else
                {
                    dbPlaylist.LeaderBoards.Add(newEntry);
                    _context.LeaderBoard.Add(newEntry);
                }

            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/MusicPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicPlaylist>> PostMusicPlaylist(MusicPlaylist musicPlaylist)
        {
            User user = _context.Uzytkownicy.Where(u => u.Id == musicPlaylist.UserId).FirstOrDefault();
            musicPlaylist.Creator = user;
            musicPlaylist.CreationDate = DateTime.Now;
            _context.MusicPlaylists.Add(musicPlaylist);
            _context.Songs.AddRange(musicPlaylist.Songs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var fdgfdg = ex.Message;
            }
            

            return CreatedAtAction("GetMusicPlaylist", new { id = musicPlaylist.Id }, musicPlaylist);
        }

        // DELETE: api/MusicPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicPlaylist(Guid id)
        {
            var musicPlaylist = _context.MusicPlaylists.Include(p => p.UsersFavourites).ThenInclude(u => u.FavouritePlaylists).Include(p => p.Songs).Include(p => p.LeaderBoards).Where(p => p.Id == id).FirstOrDefault();
            if (musicPlaylist == null)
            {
                return NotFound();
            }
            foreach (var song in musicPlaylist.Songs)
            {
                _context.Songs.Remove(song);
            }
            foreach (var entry in musicPlaylist.LeaderBoards)
            {
                _context.LeaderBoard.Remove(entry);
            }
            foreach (var user in musicPlaylist.UsersFavourites)
            {
                User userFav = _context.Uzytkownicy.Where(u => u.Id == user.Id).FirstOrDefault();
                userFav.FavouritePlaylists.Remove(musicPlaylist);
            }
            _context.MusicPlaylists.Remove(musicPlaylist);
            try
            {
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {
                var dfsgf = ex.Message;
            }
            

            return NoContent();
        }
    }
}
