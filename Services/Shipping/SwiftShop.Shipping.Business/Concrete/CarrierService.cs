using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Concrete
{
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierRepository _carrierRepository;

        public CarrierService(ICarrierRepository carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        public async Task Create(Carrier entity)
        {
            await _carrierRepository.CreateAsync(entity);
        }

        public async Task Delete(Carrier entity)
        {
            await _carrierRepository.DeleteAsync(entity);
        }

        public async Task<List<Carrier>> GetAll()
        {
            return await _carrierRepository.GetAllAsync();
        }

        public async Task<Carrier> GetById(int id)
        {
            return await _carrierRepository.GetByIdAsync(id);
        }

        public async Task Update(Carrier entity)
        {
            await _carrierRepository.UpdateAsync(entity);
        }
    }
}
