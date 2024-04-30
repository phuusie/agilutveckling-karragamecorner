using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension;

public static class CategoryEndpointExtension
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/categories");

        group.MapGet("/", GetAllCategories);
        group.MapGet("/{id}", GetCategoryById);
        group.MapPost("/", AddCategory);
        group.MapDelete("/{id}", DeleteCategory);

        return app;
    }

    private static Task GetCategoryById(ICategoryRepository repo, int id)
    {
        return repo.GetCategoryByIdAsync(id);
    }

    private static Task DeleteCategory(ICategoryRepository repo, int id)
    {
        return repo.DeleteCategoryAsync(id);
    }

    private static Task<List<Category>> GetAllCategories(ICategoryRepository repo)
    {
        return repo.GetAllCategoriesAsync();
    }

    private static Task AddCategory(ICategoryRepository repo, Category category)
    {
        return repo.AddCategoryAsync(category);
    }
}