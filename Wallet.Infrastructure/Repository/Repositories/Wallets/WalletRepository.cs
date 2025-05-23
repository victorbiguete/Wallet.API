using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Exceptions;
using Wallet.Domain.Modals;
using Wallet.Infrastructure.Data;
using Wallet.Infrastructure.Repository.Interfaces.Wallets;
using Wallet.Infrastructure.Repository.Repositories;

namespace Wallet.Infrastructure.Repository.Repositories.Wallets
{
    public class WalletRepository : BaseRepository<Domain.Modals.Wallet>, IWalletRepository
    {
        private readonly AppDBContext _context;
        public WalletRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Modals.Wallet?> GetByIdAsync(Guid userId, Guid walletId)
        {
            return await _context.Wallets.Where(x => x.UserId == userId && x.Id == walletId).FirstOrDefaultAsync();
        }

        public async Task<bool> ChangeBalance(Guid userId, Guid walletId, decimal balance)
        {
            var wallet = await GetByIdAsync(userId,walletId);

            if (wallet == null)
                return false;

            wallet.ChangeBalance(balance);

            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<decimal> GetBalance(Guid userId, Guid walletId)
        {
            try
            {
                var wallet = await _context.Wallets.Where(x => x.UserId == userId && x.Id == walletId).FirstOrDefaultAsync();

                return wallet.Balance;
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro na busca do Saldo da Carteira");
            }
        }
    }
}
