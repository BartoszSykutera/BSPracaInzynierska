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
    public class LeaderBoardsController : ControllerBase
    {
        private readonly DataContext _context;

        public LeaderBoardsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LeaderBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaderBoard>>> GetLeaderBoard()
        {
            return await _context.LeaderBoard.ToListAsync();
        }

        // GET: api/LeaderBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaderBoard>> GetLeaderBoard(Guid id)
        {
            var leaderBoard = await _context.LeaderBoard.FindAsync(id);

            if (leaderBoard == null)
            {
                return NotFound();
            }

            return leaderBoard;
        }

        // PUT: api/LeaderBoards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaderBoard(Guid id, LeaderBoard leaderBoard)
        {
            if (id != leaderBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(leaderBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaderBoardExists(id))
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

        // POST: api/LeaderBoards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeaderBoard>> PostLeaderBoard(LeaderBoard leaderBoard)
        {
            _context.LeaderBoard.Add(leaderBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaderBoard", new { id = leaderBoard.Id }, leaderBoard);
        }

        // DELETE: api/LeaderBoards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaderBoard(Guid id)
        {
            var leaderBoard = await _context.LeaderBoard.FindAsync(id);
            if (leaderBoard == null)
            {
                return NotFound();
            }

            _context.LeaderBoard.Remove(leaderBoard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeaderBoardExists(Guid id)
        {
            return _context.LeaderBoard.Any(e => e.Id == id);
        }
    }
}
