using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension;

public static class ProductCategoryEndpointExtension
{
    public static IEndpointRouteBuilder MapProductCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/productCategories");

        group.MapGet("/", GetAllProductCategories);
        group.MapGet("/{id:int}", GetProductCategory);
        group.MapPost("/{productId}/{categoryId}", AddProductCategory);
        group.MapDelete("/{id:int}", DeleteProductCategory);

        return app;
    }

    private static Task GetProductCategory(IProductCategoryRepository repo, int id)
    {
        return repo.GetProductCategoryAsync(id);
    }

    private static Task<List<ProductCategory>> GetAllProductCategories(IProductCategoryRepository repo)
    {
        return repo.GetAllProductCategoriesAsync();
    }

    private static Task DeleteProductCategory(IProductCategoryRepository repo, int id)
    {
        return repo.DeleteProductCategoryAsync(id);
    }

    private static Task AddProductCategory(IProductCategoryRepository repo, int productId, int categoryId)
    {
        return repo.AddProductCategoryAsync(productId, categoryId);
    }
}