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
    public class MultiGamesController : ControllerBase
    {
        private readonly DataContext _context;

        public MultiGamesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MultiGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultiGame>>> GetGame()
        {
            return await _context.Game.ToListAsync();
        }

        // GET: api/MultiGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultiGame>> GetMultiGame(Guid id)
        {
            var multiGame = await _context.Game.Include(g => g.Playlist).ThenInclude(p => p.Songs).Where(g => g.Id == id).FirstOrDefaultAsync();

            if (multiGame == null)
            {
                return NotFound();
            }

            return multiGame;
        }

        // GET: api/MultiGames/player/5
        //[HttpGet("player/{id}")]
        public async Task<User> GetNewPlayer(Guid id)
        {
            User user = null;
            user = await _context.Uzytkownicy.Where(u => u.Id == id).FirstOrDefaultAsync();

            
            if (user == null)
            {
                return null;
            }
            return user;
        }

        // GET: api/MultiGames/player
        [HttpPost("player")]
        public async Task<ActionResult<List<User>>> GetPlayersList(List<Guid> playerIds)
        {
            List<User> players = new List<User>();
            foreach (var player in playerIds)
            {
                User user = await GetNewPlayer(player);
                if(user != null)
                    players.Add(user);
            }
            return players;
        }

        // PUT: api/MultiGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultiGame(Guid id, MultiGame multiGame)
        {
            if (id != multiGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(multiGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiGameExists(id))
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

        // POST: api/MultiGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MultiGame>> PostMultiGame(MultiGame multiGame)
        {
            MusicPlaylist playlist = await _context.MusicPlaylists.Include(p => p.Songs).Include(p => p.Creator).Where(p => p.Id == multiGame.PlaylistId).FirstOrDefaultAsync();
            multiGame.Playlist = playlist;
            _context.Game.Add(multiGame);
            try
            {
                await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                var dg = e.Message;
            }
            

            return CreatedAtAction("GetMultiGame", new { id = multiGame.Id }, multiGame);
        }

        // DELETE: api/MultiGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultiGame(Guid id)
        {
            var multiGame = await _context.Game.FindAsync(id);
            if (multiGame == null)
            {
                return NotFound();
            }

            _context.Game.Remove(multiGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MultiGameExists(Guid id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
