using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSPracaInzynierska.Server.DB;
using BSPracaInzynierska.Shared;
using Microsoft.AspNetCore.Routing.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Common;
using Google.Apis.YouTube.v3.Data;
using System.Collections.ObjectModel;

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

        // GET: api/MultiGames/gameCode
        [HttpGet("gameCode/{code}/{playerId}")]
        public async Task<ActionResult<string>> GetGameByCode(string code, Guid playerId)
        {
            var game = await _context.Game.Include(g => g.Players).Include(g => g.Playlist).ThenInclude(p => p.Songs).Where(g => g.GameCode == code).FirstOrDefaultAsync();
            if (game != null)
            {
                User hostUser = await _context.Uzytkownicy.Where(u => u.Id == playerId).FirstOrDefaultAsync();
                game.Players.Add(hostUser);
                await _context.SaveChangesAsync();
                var multiGameCode = game.Id.ToString();
                return Ok(multiGameCode);
            }
            else
            {
                return NotFound("We can't find the game");
            }
                
        }

        // GET: api/MultiGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultiGame>> GetMultiGame(Guid id)
        {
            var multiGame = await _context.Game.Include(g => g.Players).Include(g => g.Playlist).ThenInclude(p => p.Songs).Where(g => g.Players.Any(p => p.Id == id)).FirstOrDefaultAsync();

            if (multiGame == null)
            {
                return NotFound();
            }

            return multiGame;
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
            User hostUser = await _context.Uzytkownicy.Where(u => u.Id == multiGame.UserHost).FirstOrDefaultAsync();
            hostUser.currentGameId = null;
            List<User> userList = new List<User> { hostUser };
            try
            {
                multiGame.Players = userList;
            }
            catch(Exception e)
            {
                var fgfgh = e.Message;
            }
            
            multiGame.Playlist = playlist;
            multiGame.GameCode = (multiGame.Id.GetHashCode() & 0x7fffffff).ToString();
            _context.Game.Add(multiGame);
            await _context.SaveChangesAsync();

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
