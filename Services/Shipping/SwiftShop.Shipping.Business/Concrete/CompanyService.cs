using AutoMapper;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.Dto.Dtos.Company;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCompanyDto createDto)
        {
            var creatingValue = _mapper.Map<Company>(createDto);
            await _companyRepository.CreateAsync(creatingValue);
        }

        public async Task Delete(int id)
        {
            var deletingValue = await _companyRepository.GetByIdAsync(id);
            if (deletingValue == null)
                throw new KeyNotFoundException($"Carrier with id={id} not found");
            await _companyRepository.DeleteAsync(deletingValue);
        }

        public async Task<List<ListCompanyDto>> GetAll()
        {
            var listingValues = await _companyRepository.GetAllAsync();
            return _mapper.Map<List<ListCompanyDto>>(listingValues);
        }

        public async Task<ListCompanyDto> GetById(int id)
        {
            var listingValue = await _companyRepository.GetByIdAsync(id);
            return _mapper.Map<ListCompanyDto>(listingValue);
        }

        public async Task Update(UpdateCompanyDto updateDto)
        {
            var updatingValue = _mapper.Map<Company>(updateDto);
            await _companyRepository.UpdateAsync(updatingValue);
        }
    }
}
