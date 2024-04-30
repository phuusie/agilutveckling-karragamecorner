namespace KarraGameCorner.Interfaces;

public interface IProductCategoryService<ProductCategoryDTO>
{
    Task<List<ProductCategoryDTO>> GetAllProductCategories();
    Task<ProductCategoryDTO> GetProductCategoryById(int id);

}