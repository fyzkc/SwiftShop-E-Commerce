using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity); //we should give the entity to the Delete method instead of giving the id.
        //because, delete method should only do the deletion process. If we give an Id parameter to this method, first it will try to find the data from the database,
        //then delete it. And according to SOLID principles this approach is not useful. A method must have only one job. 
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter); //this line is using for filtering with Entity Framework.
    }
}
