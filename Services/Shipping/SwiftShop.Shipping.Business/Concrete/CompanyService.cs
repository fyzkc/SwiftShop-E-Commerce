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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Create(Company entity)
        {
            await _companyRepository.CreateAsync(entity);
        }

        public async Task Delete(Company entity)
        {
            await _companyRepository.DeleteAsync(entity);
        }

        public async Task<List<Company>> GetAll()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task Update(Company entity)
        {
            await _companyRepository.UpdateAsync(entity);
        }
    }
}
