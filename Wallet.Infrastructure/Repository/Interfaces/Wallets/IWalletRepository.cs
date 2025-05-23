using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;
using Wallet.Infrastructure.Repository.Interfaces;

namespace Wallet.Infrastructure.Repository.Interfaces.Wallets
{
    public interface IWalletRepository : IBaseRepository<Domain.Modals.Wallet>
    {
        Task<bool> ChangeBalance(Guid userId,Guid walletId, decimal balance);
        Task<decimal> GetBalance(Guid userId, Guid walletId);
        Task<Domain.Modals.Wallet?> GetByIdAsync(Guid userId,Guid walletId);
    }
}
