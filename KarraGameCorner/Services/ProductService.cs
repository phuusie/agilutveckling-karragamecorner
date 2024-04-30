using KarraGameCorner.Interfaces;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Services;

public class ProductService(IHttpClientService httpClientService) : IProductService<ProductDTO>
{

    private List<ProductDTO> _products = new();
    private ProductDTO _product = new();


    public async Task<List<ProductDTO>> GetAllProducts()
    {
        var response = await httpClientService.GetAsync("products");
        _products = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
        return _products;
    }

    public async Task<List<ProductDTO>> GetTopSelling()
    {
        await GetAllProducts();
        return _products.OrderByDescending(p => p.Price).Take(5).ToList(); //Temporär
    }

    public async Task<List<ProductDTO>> GetNewArrivals()
    {
        await GetAllProducts();
        return _products.OrderByDescending(p => p.Id).Take(5).ToList(); //Temporär
    }

    public async Task<List<ProductDTO>> GetRecommended()
    {
        await GetAllProducts();
        return _products.OrderByDescending(p => p.Name).Take(5).ToList(); //Temporär
    }

    public async Task<List<ProductDTO>> SearchProductsAsync(string search)
    {
        _products = await GetAllProducts();
        return _products
            .Where(p => p.Name.ToLower()
                .Contains(search.ToLower())).Take(5).ToList();
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var response = await httpClientService.GetAsync($"products/{id}");
        _product = await response.Content.ReadFromJsonAsync<ProductDTO>();
        return _product;
    }

    public async Task<ProductDTO> GetProduceByName(string search)
    {
        var response = await httpClientService.GetAsync($"products/{search}");
        _product = await response.Content.ReadFromJsonAsync<ProductDTO>();
        return _product;
    }

    public async Task<ProductDTO> CreateProduct(ProductDTO product)
    {
        var response = await httpClientService.PostAsync("products", product);
        _product = await response.Content.ReadFromJsonAsync<ProductDTO>();
        return _product;
    }

    public async Task<ProductDTO> UpdateProduct(ProductDTO product)
    {
        var response = await httpClientService.PostAsync($"products/{product.Id}", product);
        _product = await response.Content.ReadFromJsonAsync<ProductDTO>();
        return _product;
    }

    public async Task DeleteProduct(int id)
    {
        var response = await httpClientService.DeleteAsync($"products/{id}");
        _products.Remove(_products.FirstOrDefault(p => p.Id == id));
    }
}