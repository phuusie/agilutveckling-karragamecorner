using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface ICartItemRepository
{
    Task AddCartItemAsync(CartItem cartItem);
    Task DeleteCartItemAsync(int id);
    Task<List<CartItem>> GetAllCartItemsAsync();
}