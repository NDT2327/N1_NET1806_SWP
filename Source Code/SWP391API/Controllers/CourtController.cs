using Microsoft.AspNetCore.Mvc;
using SWP391API.Domain.Contracts;
using SWP391API.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SWP391API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService)
        {
            _courtService = courtService;
        }

        [HttpGet("{courtId}")]
        public async Task<ActionResult<Court>> GetCourtById(int courtId)
        {
            var court = await _courtService.GetByIdAsync(courtId);
            if (court == null)
            {
                return NotFound();
            }
            return Ok(court);
        }

        [HttpPost]
        [ActionName(nameof(GetCourtById))]
        public async Task<ActionResult<Court>> AddInformation([FromBody]Court court)
        {
            if (court == null)
            {
                return BadRequest("Court is null.");
            }

            var createdCourt = await _courtService.AddSync(court);
            return CreatedAtAction(nameof(GetCourtById), new { id = createdCourt.CourtId }, createdCourt);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Court>>> GetAllAsync()
        {
            var courts = await _courtService.GetAllAsync();
            return Ok(courts);
        }

        [HttpPut("{courtId}")]
        public async Task<IActionResult> UpdateCourt(int courtId, Court court)
        {
            if (courtId != court.CourtId)
            {
                return BadRequest();
            }
            await _courtService.UpdateSync(court);
            return NoContent();
        }

        [HttpDelete("{courtId}")]
        public async Task<IActionResult> RemoveCourt(int courtId, CancellationToken cancellationToken)
        {
            await _courtService.DeleteSync(courtId, cancellationToken);
            return NoContent();
        }
    }
}
