using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;
using Wallet.Services.Contracts.Request.Users;
using Wallet.Services.Contracts.Response.Users;

namespace Wallet.Services.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateAsync(CreateUserRequest request);
        Task<bool> UpdateAsync(UpdateUserRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task<UserResponse> GetByIdAsync(Guid id);
        Task<List<UserResponse>> GetAll();
        Task<bool> ChangePassword(Guid id, string password);
    }
}
