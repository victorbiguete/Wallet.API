using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;

namespace Wallet.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<bool> CreateAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(T obj);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAll();
    }
}
