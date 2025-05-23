using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Services.Contracts.Request.Wallet;

namespace Wallet.Services.Service.Interfaces
{
    public interface IWalletService
    {
        Task<bool> ChangeBalance(GetWallatRequest request, decimal balance);
        Task<decimal> GetBalance(Guid userId, Guid walletId);
        Task<bool> DeleteAsync(Guid id);
    }
}
