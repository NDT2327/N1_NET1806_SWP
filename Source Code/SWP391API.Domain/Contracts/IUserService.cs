using SWP391API.Domain.Models;
using SWP391API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391API.Domain.Contracts
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> AddAndUpdateUser(User userObj);
    }
}
