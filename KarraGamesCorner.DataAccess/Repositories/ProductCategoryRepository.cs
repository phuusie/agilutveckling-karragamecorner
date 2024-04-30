using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class ProductCategoryRepository(KarraGameCornerDbContext context) : IProductCategoryRepository
{
    public async Task<List<ProductCategory>> GetProductCategoryAsync(int id)
    {
        return await context.ProductCategories
            .Where(pc => pc.ProductId == id)
            .ToListAsync();
    }

    public async Task AddProductCategoryAsync(int productId, int categoryId)
    {
        var productCategory = new ProductCategory
        {
            ProductId = productId,
            CategoryId = categoryId
        };
        if (await context.ProductCategories.AnyAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId))
        {
            throw new Exception("Product category already exists");
        }
        await context.ProductCategories.AddAsync(productCategory);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductCategoryAsync(int id)
    {
        var productCategory = await context.ProductCategories.FindAsync(id);
        if (productCategory is null)
        {
            throw new Exception("Product category not found");
        }
        context.ProductCategories.Remove(productCategory);
        await context.SaveChangesAsync();
    }

    public async Task<List<ProductCategory>> GetAllProductCategoriesAsync()
    {
        return await context.ProductCategories.ToListAsync();
    }
}