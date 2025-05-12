using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Abstract
{
    public interface IGenericService<TEntity, TCreateDto, TUpdateDto, TListDto> where TEntity : class
    {
        Task Create(TCreateDto createDto);
        Task Update(TUpdateDto updateDto);
        Task Delete(int id);
        Task<TListDto> GetById(int id);
        Task<List<TListDto>> GetAll();
    }
}
