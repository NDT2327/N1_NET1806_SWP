using Microsoft.EntityFrameworkCore;
using SWP391API.Domain.Contracts;
using SWP391API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391API.Infrastructure.Services
{
    public class CourtService(ApplicationDbContext db) : ICourtSevice
    {

        public async Task<Court> GetByIdAsync(int courtId, CancellationToken cancellation) => await db.Courts.FirstOrDefaultAsync(c => c.CourtId == courtId, cancellation);
    }
}
