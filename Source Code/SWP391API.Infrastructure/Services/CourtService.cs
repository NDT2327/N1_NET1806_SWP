using Microsoft.EntityFrameworkCore;
using SWP391API.Domain.Contracts;
using SWP391API.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SWP391API.Infrastructure.Services
{
    public class CourtService : ICourtService
    {
        private readonly ApplicationDbContext _db;

        public CourtService(ApplicationDbContext db)
        {
            _db = db; // Sửa lại dòng này
        }

        public async Task<Court> GetByIdAsync(int courtId)
        {
            return await _db.Courts.FindAsync(courtId);
        }
            


        public async Task<IEnumerable<Court>> GetAllAsync()
        {
            return await _db.Courts.ToListAsync();
        }

        public async Task<Court> AddSync(Court court)
        {
            _db.Courts.Add(court);
            await _db.SaveChangesAsync();
            return court;
        }

        public async Task DeleteSync(int courtId, CancellationToken cancellation)
        {
            var court = await GetByIdAsync(courtId);
            if (court != null)
            {
                _db.Courts.Remove(court);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateSync(Court court)
        {
            _db.Entry(court).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
