using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension;

public static class ProductEndpointExtension
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", GetAllProducts);
        group.MapGet("/{id:int}", GetProductById);
        group.MapPost("/", AddProduct);
        group.MapPut("/{id:int}", UpdateProduct);
        group.MapDelete("/{id:int}", DeleteProduct);
        group.MapGet("/{search}", SearchProducts);
        group.MapGet("/esrb/{esrb}", GetProductsByEsrb);
        group.MapGet("/{minPrice:double}/{maxPrice:double}", GetProductsByPrice);

        return app;
    }

    private static Task GetProductsByPrice(IProductRepository repo, double minPrice, double maxPrice)
    {
        return repo.GetProductsByPriceAsync(minPrice, maxPrice);
    }

    private static Task<List<Product>> GetProductsByEsrb(IProductRepository repo, string esrb)
    {
        return repo.GetProductsByEsrbAsync(esrb);
    }


    private static Task<List<Product>> SearchProducts(IProductRepository repo, string search)
    {
        return repo.GetProductsBySearchAsync(search);
    }

    private static Task DeleteProduct(IProductRepository repo, int id)
    {
        return repo.DeleteProductAsync(id);
    }

    private static Task UpdateProduct(IProductRepository repo, Product product, int id)
    {
        return repo.UpdateProductAsync(id, product);
    }

    private static Task AddProduct(IProductRepository repo, Product product)
    {
        return repo.AddProductAsync(product);
    }

    private static Task<Product> GetProductById(IProductRepository repo, int id)
    {
        return repo.GetProductByIdAsync(id);
    }

    private static Task<List<Product>> GetAllProducts(IProductRepository repo)
    {
        return repo.GetAllProductsAsync();
    }
}