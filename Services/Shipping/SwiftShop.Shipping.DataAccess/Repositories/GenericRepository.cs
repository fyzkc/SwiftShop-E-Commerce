using Microsoft.EntityFrameworkCore;
using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShippingContext _shippingContext;

        public GenericRepository(ShippingContext shippingContext)
        {
            _shippingContext = shippingContext;
        }

        public async Task CreateAsync(T entity)
        {
            _shippingContext.Set<T>().Add(entity);
            await _shippingContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _shippingContext.Set<T>().Remove(entity);
            await _shippingContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _shippingContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _shippingContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _shippingContext.Set<T>().Update(entity);
            await _shippingContext.SaveChangesAsync();
        }
    }
}
