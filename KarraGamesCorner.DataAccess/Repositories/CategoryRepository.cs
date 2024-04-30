using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class CategoryRepository(KarraGameCornerDbContext context) : ICategoryRepository
{
    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task AddCategoryAsync(Category category)
    {
        if (await context.Categories.AnyAsync(c => c.Name == category.Name))
        {
            throw new Exception("Category already exists");
        }
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category is null)
        {
            throw new Exception("Category not found");
        }
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }

    public Task<List<Category>> GetAllCategoriesAsync()
    {
        return context.Categories.ToListAsync();
    }
}