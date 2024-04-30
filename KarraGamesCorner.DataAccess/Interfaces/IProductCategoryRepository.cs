using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IProductCategoryRepository
{
    Task<List<ProductCategory>> GetProductCategoryAsync(int id);
    Task AddProductCategoryAsync(int productId, int categoryId);
    Task DeleteProductCategoryAsync(int id);
    Task<List<ProductCategory>> GetAllProductCategoriesAsync();
}