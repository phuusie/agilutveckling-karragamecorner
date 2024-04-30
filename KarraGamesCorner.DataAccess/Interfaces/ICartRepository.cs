using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCartByIdAsync(int id);
    Task<List<Cart>> GetAllCartsAsync();
    Task AddCartAsync(Cart cart);
    Task UpdateCartAsync(int id, Cart cart);
    Task DeleteCartAsync(int id);
    Task AddCartItemToCartAsync(int id, CartItem cartItem);
    Task RemoveCartItemFromCartAsync(int id, int cartItemId);
}