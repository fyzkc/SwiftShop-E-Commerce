using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.Dto.Dtos.Company;

namespace SwiftShop.Shipping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Authorize(Policy = "ShippingReadOrFullPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var allCompanies = await _companyService.GetAll();
            return Ok(allCompanies);
        }

        [Authorize(Policy = "ShippingReadOrFullPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetById(id);
            return Ok(company);
        }

        [Authorize(Policy = "ShippingFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            await _companyService.Create(createCompanyDto);
            return Ok("Company created successfully!");
        }

        [Authorize(Policy = "ShippingFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDto updateCompanyDto)
        {
            await _companyService.Update(updateCompanyDto);
            return Ok("Company updated successfully!");
        }

        [Authorize(Policy = "ShippingFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.Delete(id);
            return Ok("Company deleted successfully!");
        }
    }
}
