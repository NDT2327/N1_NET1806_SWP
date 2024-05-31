using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP391API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP391API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly BadmintonCourtDbContext _dbContext;

        public CourtController(BadmintonCourtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Court>>> GetCourts()
        {
            if (_dbContext.Courts == null)
            {
                return NotFound();
            }
            return await _dbContext.Courts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Court>> GetCourts(int id)
        {
            if (_dbContext.Courts == null)
            {
                return NotFound();
            }
            var court = await _dbContext.Courts.FindAsync(id);
            if (court == null)
            {
                return NotFound();
            }
            return court;
        }


        [HttpPost]
        public async Task<ActionResult<Court>> PostCourt(Court court)
        {
            if (_dbContext.Accounts == null || !await _dbContext.Accounts.AnyAsync(a => a.UserID == court.UserId))
            {
                return BadRequest("Invalid UserID. The UserID does not exist in the Account table.");
            }

            _dbContext.Courts.Add(court);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourtExists(court.CourtId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourt", new { id = court.CourtId }, court);
        }

        private bool CourtExists(int id)
        {
            return (_dbContext.Courts?.Any(e => e.CourtId == id)).GetValueOrDefault();
        }
    }


}

