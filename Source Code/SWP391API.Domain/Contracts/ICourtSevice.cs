using SWP391API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391API.Domain.Contracts
{
    public interface ICourtSevice
    {
        // Create
        // Update
        Task<Court> GetByIdAsync(int courtId, CancellationToken cancellation);
    }
}
