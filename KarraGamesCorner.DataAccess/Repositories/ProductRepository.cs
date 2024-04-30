using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Enums;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class ProductRepository(KarraGameCornerDbContext context) : IProductRepository
{
    public async Task AddProductAsync(Product product)
    {
        if (await context.Products.AnyAsync(p => p.Name == product.Name))
        {
            throw new Exception("Product already exists");
        }
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await context.Products.Include(product => product.Categories)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        return product;
    }

    public async Task<Product> GetProductByNameAsync(string name)
    {
        var product = await context.Products.Include(product => product.Categories).FirstOrDefaultAsync(p => p.Name == name);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        return product;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await context.Products.Include(product => product.Categories).ToListAsync();
    }

    public async Task UpdateProductAsync(int id, Product updateProduct)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        product.Name = updateProduct.Name;
        product.Description = updateProduct.Description;
        product.Price = updateProduct.Price;
        product.Quantity = updateProduct.Quantity;
        product.ESRB = updateProduct.ESRB;
        product.Picture = updateProduct.Picture;
        product.Status = updateProduct.Status;
        product.Categories = updateProduct.Categories;

        await context.SaveChangesAsync();
    }


    public async Task<List<Product>> GetProductsByEsrbAsync(string esrb)
    {
        if (!Enum.TryParse<EntertainmentSoftwareRatingBoard>(esrb, out var esrbEnum))
        {
            throw new ArgumentException("Invalid ESRB value", nameof(esrb));
        }
        var products = await context.Products
            .AsNoTracking()
            .Include(product => product.Categories)
            .Where(p => p.ESRB == esrbEnum)
            .ToListAsync();

        return products;
    }

    public async Task<List<Product>> GetProductsByPriceAsync(double minPrice, double maxPrice)
    {
        var products = await context.Products.Include(product => product.Categories).Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToListAsync();
        return products;
    }

    public async Task<List<Product>> GetProductsBySearchAsync(string search)
    {
        var products = await context.Products
            .Include(product => product.Categories)
            .Where(p => p.Name.Contains(search) || p.Description.Contains(search))
            .ToListAsync();
        return products;
    }
}