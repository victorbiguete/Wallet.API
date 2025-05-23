using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Exceptions;
using Wallet.Domain.Modals;
using Wallet.Infrastructure.Repository.Interfaces.Users;
using Wallet.Services.Contracts.Request.Users;
using Wallet.Services.Contracts.Response.Users;
using Wallet.Services.Mapping.UserMap;
using Wallet.Services.Service.Interfaces;

namespace Wallet.Services.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IWalletService _walletService;

        public UserService(IUserRepository userRepository, IAuthService authService, IWalletService walletService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _walletService = walletService;
        }

        public async Task<bool> ChangePassword(Guid id, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(CreateUserRequest request)
        {
            var userExist = await _userRepository.SearchUsername(request.username);

            if (userExist)
                throw new DomainException("Já existe esse Username cadastrado");
            
            _authService.GeneratePasswordHash(request.password,out byte[] hash,out byte[] salt);

            var user = request.MapToUser(hash,salt);

            user.WalletId = user.Wallet.Id;

            await _userRepository.CreateAsync(user);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if(user == null)
                    return false;

                if(user.Wallet.Balance != 0)
                    return false;
                //await _walletService.DeleteAsync(user.WalletId);

                await _userRepository.DeleteAsync(user);

                return true;
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um Erro durante a solicitação de Remoção do Usuario: " + ex.Message);
            }
        }

        public async Task<List<UserResponse>> GetAll()
        {
            try
            {
                var user = await _userRepository.GetAll();

                var userResponse =  user.MapToListUserResponse();

                return userResponse;
            }
            catch (Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante a solicitação da busca pelo Usuario" + ex.Message);
            }
        }

        public async Task<UserResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                var userResponse = user.MapToUserResponse();

                return userResponse;
            }
            catch (Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante a solicitação da busca pelo Usuario" + ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(UpdateUserRequest request)
        {
            try
            {
                var userExist = await _userRepository.GetByIdAsync(request.id);

                if (userExist == null)
                    return false;

                if (string.IsNullOrEmpty(request.password))
                    userExist.MapToUserUpdate(request);
                else
                {
                    _authService.GeneratePasswordHash(request.password,out byte[] hash, out byte[] salt);

                    userExist.MapToUserUpdate(request,hash,salt);
                }

                await _userRepository.UpdateAsync(userExist);

                return true;

            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante a solicitação de Atualização do Usuario: " + ex.Message);
            }
        }
    }
}
