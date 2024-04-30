using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Interfaces;

public interface ICartItemService<CartItemDTO>
{
    Task<List<CartItemDTO>>? GetCartItemsAsync();
    Task<List<CartItemDTO>> GetMemberCartItemsAsync(int userId);
    Task<CartItemDTO> AddToCart(CartItemDTO cartItem);
    Task<CartItemDTO> UpdateCartItem(CartItemDTO cartItem);
    Task<CartItemDTO> RemoveFromCart(CartItemDTO cartItem);
}