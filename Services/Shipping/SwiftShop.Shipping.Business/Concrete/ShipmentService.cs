using AutoMapper;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.DataAccess.Repositories;
using SwiftShop.Shipping.Dto.Dtos.Shipment;
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
        private readonly IMapper _mapper;

        public ShipmentService(ShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateShipmentDto createDto)
        {
            var creatingValue = _mapper.Map<Shipment>(createDto);
            await _shipmentRepository.CreateAsync(creatingValue);
        }

        public async Task Delete(int id)
        {
            var deletingValue = await _shipmentRepository.GetByIdAsync(id);
            if (deletingValue == null)
                throw new KeyNotFoundException($"Carrier with id={id} not found");
            await _shipmentRepository.DeleteAsync(deletingValue);
        }

        public async Task<List<ListShipmentDto>> GetAll()
        {
            var listingValues = await _shipmentRepository.GetAllAsync();
            return _mapper.Map<List<ListShipmentDto>>(listingValues);
        }

        public async Task<ListShipmentDto> GetById(int id)
        {
            var listingValue = await _shipmentRepository.GetByIdAsync(id);
            return _mapper.Map<ListShipmentDto>(listingValue);
        }

        public async Task Update(UpdateShipmentDto updateDto)
        {
            var updatingValue = _mapper.Map<Shipment>(updateDto);
            await _shipmentRepository.UpdateAsync(updatingValue);
        }
    }
}
