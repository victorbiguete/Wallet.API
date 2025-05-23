using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;
using Wallet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Wallet.Infrastructure.Repository.Interfaces;

namespace Wallet.Infrastructure.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: Base
    {
        private readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> CreateAsync(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> DeleteAsync(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var obj = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return obj;
        }

        public virtual async Task<bool> UpdateAsync(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
