using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Interfaces;

public interface ICartService
{
    event Action OnChange;
    Task<CartDTO> GetCart();
    Task LoadCart();
    Task<CartDTO> GetCartByUserId(int userId);
    Task AddToCart(CartItemDTO cartItem);
    Task<CartDTO> UpdateCartItem(CartItemDTO cartItem);
    Task RemoveCart();
    Task<CartDTO> RemoveFromCart(CartItemDTO cartItem);
}