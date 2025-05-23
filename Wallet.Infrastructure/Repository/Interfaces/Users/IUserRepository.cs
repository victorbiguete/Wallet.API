using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;
using Wallet.Infrastructure.Repository.Interfaces;

namespace Wallet.Infrastructure.Repository.Interfaces.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ChangePassword(Guid id, string password);
        Task<bool> SearchUsername(string username);
    }
}
