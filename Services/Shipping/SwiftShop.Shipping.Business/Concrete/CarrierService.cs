using AutoMapper;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.Dto.Dtos.Carrier;
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
        private readonly IMapper _mapper;

        public CarrierService(ICarrierRepository carrierRepository, IMapper mapper)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCarrierDto createDto)
        {
            var creatingValue = _mapper.Map<Carrier>(createDto);
            await _carrierRepository.CreateAsync(creatingValue);
        }

        public async Task Delete(int id)
        {
            var deletingValue = await _carrierRepository.GetByIdAsync(id);
            if (deletingValue == null)
                throw new KeyNotFoundException($"Carrier with id={id} not found");
            await _carrierRepository.DeleteAsync(deletingValue);
        }

        public async Task<List<ListCarrierDto>> GetAll()
        {
            var listingValues = await _carrierRepository.GetAllAsync();
            return _mapper.Map<List<ListCarrierDto>>(listingValues);
        }

        public async Task<ListCarrierDto> GetById(int id)
        {
            var listingValue = await _carrierRepository.GetByIdAsync(id);
            return _mapper.Map<ListCarrierDto>(listingValue);
        }

        public async Task Update(UpdateCarrierDto updateDto)
        {
            var updatingValue = _mapper.Map<Carrier>(updateDto);
            await _carrierRepository.UpdateAsync(updatingValue);
        }
    }
}
