using KarraGameCorner.Interfaces;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Services;

public class CategoryService(IHttpClientService httpClientService) : ICategoryService<CategoryDTO>
{
    private List<CategoryDTO>? _categories = new();
    private List<ProductCategoryDTO>? _productCategories = new();
    private CategoryDTO _category = new();

    public async Task<List<CategoryDTO>?> GetAllCategories()
    {
        var response = await httpClientService.GetAsync("/categories");
        _categories = await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
        return _categories;
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var response = await httpClientService.GetAsync($"/categories/{id}");
        _category = await response.Content.ReadFromJsonAsync<CategoryDTO>();
        return _category;
    }

    public async Task<List<CategoryDTO>> GetCategoriesByIds(List<int> categoryIds)
    {
        var categories = new List<CategoryDTO>();
        foreach (var id in categoryIds)
        {
            var response = await httpClientService.GetAsync($"/categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadFromJsonAsync<CategoryDTO>();
                categories.Add(category);
            }
        }
        return categories;
    }
}