using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interface
{
    public interface IGenericRepository<T> 
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(int Id);
        Task<int> SaveChangeAsync();

    }
}
