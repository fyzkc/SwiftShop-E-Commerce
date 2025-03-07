using SwiftShop.Catalog.Dtos.CategoryDtos;

namespace SwiftShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        //Task keyword defines the method as asynchronous. 
        //Asynchronous methods ensure that the UI (user interface) does not stop while operations are being performed in the background.
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<ResultCategoryDto> GetCategoryByIdAsync(string categoryId);
    }
}
