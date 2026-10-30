using E_Commerce.Application.Interface;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StoreContext context;
        public GenericRepository(StoreContext _context)
        {
           context = _context;
            
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().Where(x => !EF.Property<bool>(x, "IsDeleted")).ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => EF.Property<int>(x, "ID") == id&& !EF.Property<bool>(x, "IsDeleted"));
        }
        public async Task<T> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await context.Set<T>().FindAsync(Id);
            if (entity == null) { return; }
            context .Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangeAsync()
        {
          return  await context.SaveChangesAsync();    
              
        
        }
    }
}
