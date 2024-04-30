using KarraGameCorner.Interfaces;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Services;

public class ProductCategoryService(IHttpClientService httpClientService) : IProductCategoryService<ProductCategoryDTO>
{
    private List<ProductCategoryDTO> _productCategories = new();
    private ProductCategoryDTO _productCategory = new();

    public async Task<List<ProductCategoryDTO>> GetAllProductCategories()
    {
        var response = await httpClientService.GetAsync("productCategories");
        _productCategories = await response.Content.ReadFromJsonAsync<List<ProductCategoryDTO>>();
        return _productCategories;
    }

    public async Task<ProductCategoryDTO> GetProductCategoryById(int id)
    {
        var response = await httpClientService.GetAsync($"productCategories/{id}");
        _productCategory = await response.Content.ReadFromJsonAsync<ProductCategoryDTO>();
        return _productCategory;
    }

}