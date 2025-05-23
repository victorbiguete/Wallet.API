using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Exceptions;
using Wallet.Infrastructure.Repository.Interfaces.Wallets;
using Wallet.Services.Contracts.Request.Wallet;
using Wallet.Services.Service.Interfaces;

namespace Wallet.Services.Service.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<bool> ChangeBalance(GetWallatRequest request, decimal balance)
        {
            try
            {
                var result = await _walletRepository.ChangeBalance(request.UserId,request.WalletId, balance);

                return result;
            }
            catch (Exception ex)
            {
                throw new DomainException("Ocorreu um Erro durante a alteração do saldo");
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var wallet = await _walletRepository.GetByIdAsync(id);

                if(wallet == null)
                    return false;

                await _walletRepository.DeleteAsync(wallet);
                
                return true;
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro na solicitação de Remoção da Wallet: " + ex.Message);
            }
        }

        public async Task<decimal> GetBalance(Guid userId, Guid walletId)
        {
            try
            {
                var balance = await _walletRepository.GetBalance(userId,walletId);
                return balance;
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante a solicitação do saldo");
            }
        }
    }
}
