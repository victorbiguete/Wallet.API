using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;
using Wallet.Infrastructure.Data;
using Wallet.Infrastructure.Repository.Interfaces.Users;
using Wallet.Infrastructure.Repository.Repositories;

namespace Wallet.Infrastructure.Repository.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ChangePassword(Guid id,string password)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
                return false;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(w => w.Wallet)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SearchUsername(string username)
        {
            var user = await _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();

            if (user == null)
                return false;

            return true;
        }
    }
}
