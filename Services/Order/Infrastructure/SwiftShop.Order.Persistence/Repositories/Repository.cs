using Microsoft.EntityFrameworkCore;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _orderContext;

        public Repository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task CreateAsync(T entity)
        {
            _orderContext.Set<T>().Add(entity); //Set<T>() method calls the corresponding DbSet<T>.
            await _orderContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _orderContext.Set<T>().Remove(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _orderContext.Set<T>().ToListAsync();
            
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _orderContext.Set<T>().SingleOrDefaultAsync(filter);
            //SingleOrDefault method returns the single data that meets the specific query.
            //If there are more than one record that meets that query, then it throws an error. 
            //If there is no record, then it returns null.
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _orderContext.Set<T>().FindAsync(id);
            //FirstOrDefaultAsync() method uses a lambda expression for making a query and to find the related data.
            //But in here, we don't know what is the table name or the property's name.
            //So that we should use FindAsync() method. This method only searchs with the primary keys. 
            //It knows automatically what is the primary key. So that it doesn't need to know the Id property's name.
        }

        public async Task UpdateAsync(T entity)
        {
            _orderContext.Set<T>().Update(entity);
            await _orderContext.SaveChangesAsync();
        }
    }
}
