using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
    Task<List<Category>> GetAllCategoriesAsync();
}