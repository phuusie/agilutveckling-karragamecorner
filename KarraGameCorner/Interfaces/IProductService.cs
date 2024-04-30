using System.Net;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Interfaces;

public interface IProductService<ProductDTO>
{
    Task <List<ProductDTO>> GetAllProducts();
    Task<List<ProductDTO>> GetTopSelling();
    Task<List<ProductDTO>> GetNewArrivals();
    Task<List<ProductDTO>> GetRecommended();
    Task<List<ProductDTO>> SearchProductsAsync(string search);
    Task <ProductDTO> GetProductById(int id);

    Task<ProductDTO> GetProduceByName(string name);
    Task<ProductDTO> CreateProduct(ProductDTO product);
    Task <ProductDTO> UpdateProduct(ProductDTO product);
    Task DeleteProduct(int id);
}