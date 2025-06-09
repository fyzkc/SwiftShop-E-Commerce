using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.CategoryDtos;
using SwiftShop.Catalog.Services.CategoryServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var allCategories = await _categoryService.GetAllCategoriesAsync();
            return Ok(allCategories);
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            return Ok(category);
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Category added successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Category updated successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return Ok("Category deleted successfully");
        }
    }
}
