using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Interfaces;

public interface ICategoryService<CategoryDTO>
{
    Task<List<CategoryDTO>> GetAllCategories();
    Task<CategoryDTO> GetCategoryById(int id);
    Task<List<CategoryDTO>> GetCategoriesByIds(List<int> categoryIds);
}