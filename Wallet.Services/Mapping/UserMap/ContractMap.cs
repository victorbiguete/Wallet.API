using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;
using Wallet.Services.Contracts.Request.Users;
using Wallet.Services.Contracts.Response.Users;

namespace Wallet.Services.Mapping.UserMap
{
    public static class ContractMap
    {
        public static User MapToUser(this CreateUserRequest request, byte[] hash, byte[] salt)
        {
            return new User
            {
                Name = request.name,
                Username = request.username,
                PasswordHash = hash,
                PasswordSalt = salt
            };
        }

        public static void MapToUserUpdate(this User user,UpdateUserRequest request, byte[] hash, byte[] salt)
        {
            user.Name = !string.IsNullOrEmpty(request.name) ? request.name : user.Name;
            
            user.Username = !string.IsNullOrEmpty(request.username) ? request.username : user.Username;
            
            user.PasswordHash = hash;
            
            user.PasswordSalt = salt;
            
            user.LastUpdatedAt = DateTime.Now;
        }

        public static void MapToUserUpdate(this User user, UpdateUserRequest request)
        {
            user.Name = !string.IsNullOrEmpty(request.name) ? request.name : user.Name;

            user.Username = !string.IsNullOrEmpty(request.username) ? request.username : user.Username;

            user.LastUpdatedAt = DateTime.Now;
        }

        public static List<UserResponse> MapToListUserResponse(this List<User> user)
        {
            return user.Select(user => new UserResponse
            (
                Id : user.Id,
                walletId : user.WalletId,
                Name : user.Name,
                CreatedAt : user.CreatedAt,
                LastUpdatedAt : user.LastUpdatedAt
            )).ToList();
        }

        public static UserResponse MapToUserResponse(this User user)
        {
            return new UserResponse
            (
                Id : user.Id,
                Name : user.Name,
                walletId : user.WalletId,
                CreatedAt : user.CreatedAt,
                LastUpdatedAt : user.LastUpdatedAt
            );
        }


    }
}
