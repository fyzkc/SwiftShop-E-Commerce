using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.DataAccess.Repositories;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Concrete
{
    public class ShipmentService : IShipmentService
    {
        private readonly ShipmentRepository _shipmentRepository;

        public ShipmentService(ShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task Create(Shipment entity)
        {
            await _shipmentRepository.CreateAsync(entity);

        }

        public async Task Delete(Shipment entity)
        {
            await _shipmentRepository.DeleteAsync(entity);
        }

        public async Task<List<Shipment>> GetAll()
        {
            return await _shipmentRepository.GetAllAsync();
        }

        public async Task<Shipment> GetById(int id)
        {
            return await _shipmentRepository.GetByIdAsync(id);
        }

        public async Task Update(Shipment entity)
        {
            await _shipmentRepository.UpdateAsync(entity);
        }
    }
}
