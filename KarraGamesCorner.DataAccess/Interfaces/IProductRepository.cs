using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> GetProductByNameAsync(string name);
    Task<List<Product>> GetAllProductsAsync();
    Task UpdateProductAsync(int id, Product product);
    Task<List<Product>> GetProductsByEsrbAsync(string esrb);
    Task<List<Product>> GetProductsByPriceAsync(double minPrice, double maxPrice);
    Task<List<Product>> GetProductsBySearchAsync(string search);
}