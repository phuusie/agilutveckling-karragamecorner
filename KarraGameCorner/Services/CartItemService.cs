using KarraGameCorner.Interfaces;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Services;

public class CartItemService(IHttpClientService httpClientService) : ICartItemService<CartItemDTO>
{
    public async Task<List<CartItemDTO>> GetCartItemsAsync(int userId)
    {
        await httpClientService.GetAsync($"carts/{userId}");
        return new List<CartItemDTO>();
    }

    public async Task<List<CartItemDTO>>? GetCartItemsAsync()
    {
        await httpClientService.GetAsync("carts");
        return new List<CartItemDTO>();
    }

    public Task<List<CartItemDTO>> GetMemberCartItemsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CartItemDTO> AddToCart(CartItemDTO cartItem)
    {
        await httpClientService.PostAsync("carts", cartItem);
        return cartItem;
    }

    public async Task<CartItemDTO> UpdateCartItem(CartItemDTO cartItem)
    {
        await httpClientService.PutAsync($"carts/{cartItem.Id}", cartItem);
        return cartItem;
    }

    public async Task<CartItemDTO> RemoveFromCart(CartItemDTO cartItem)
    {
        await httpClientService.DeleteAsync($"carts/{cartItem.Id}");
        return cartItem;
    }
}