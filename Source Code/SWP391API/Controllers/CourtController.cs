using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP391API.Attributes;
using SWP391API.Domain.Contracts;
using SWP391API.Infrastructure;
using SWP391API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP391API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtSevice _courtSevice;

        public CourtController(ICourtSevice courtSevice)
        {
            _courtSevice = courtSevice;
        }

       [HttpGet]
        [Authorize]
       public Task<Court> GetAsync(int courtId, CancellationToken cancellation)
        {
            return _courtSevice.GetByIdAsync(courtId, cancellation);
        }
    }


}

