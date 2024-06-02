using SWP391API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391API.Domain.Contracts
{
    public interface ICourtService
    {
        //get all court
        Task<IEnumerable<Court>> GetAllAsync();
        Task<Court> GetByIdAsync(int courtId);
        //create
        Task<Court> AddSync(Court court);
        //remove
        Task DeleteSync(int courtId, CancellationToken cancellation);
        //update
        Task UpdateSync(Court court);
    }
}
