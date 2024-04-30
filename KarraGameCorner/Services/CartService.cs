using Blazored.LocalStorage;
using KarraGameCorner.Interfaces;
using KarraGameCorner.Shared.DTOs;

namespace KarraGameCorner.Services;

public class CartService(ILocalStorageService localStorageService
    , ICartItemService<CartItemDTO> cartItemService) 
    : ICartService
{
    private CartDTO _cart = new();
    private CartItemDTO _cartItem = new();

    public event Action OnChange;

    public async Task<CartDTO> GetCart()
    {
        _cart = await localStorageService.GetItemAsync<CartDTO>("cart") ?? new CartDTO();
        return _cart;
    }

    public async Task LoadCart()
    {
        await localStorageService.SetItemAsync("cart", _cart);
        OnChange?.Invoke();
    }

    public async Task<CartDTO> GetCartByUserId(int userId)
    {
        _cart.Items = await cartItemService.GetMemberCartItemsAsync(userId);
        return _cart;
    }

    public async Task AddToCart(CartItemDTO cartItem)
    {
        _cart = await localStorageService.GetItemAsync<CartDTO>("cart") ?? new CartDTO();

        var existingItem = _cart.Items.FirstOrDefault(i => i.Product.Id == cartItem.Product.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += cartItem.Quantity;
        }
        else
        {
            _cart.Items.Add(cartItem);
        }

        await localStorageService.SetItemAsync("cart", _cart);
        OnChange?.Invoke();
    }

    public async Task<CartDTO> UpdateCartItem(CartItemDTO cartItem)
    {
        _cartItem = await cartItemService.UpdateCartItem(cartItem);
        _cart.Items.Add(_cartItem);
        OnChange?.Invoke();
        return _cart;
    }

    public async Task RemoveCart()
    {
        _cart.Items.Clear();
        await localStorageService.RemoveItemAsync("cart");
        _cart.Items.Clear();
        OnChange?.Invoke();
    }

    public async Task<CartDTO> RemoveFromCart(CartItemDTO cartItem)
    {
        _cartItem = await cartItemService.RemoveFromCart(cartItem);
        _cart.Items.Remove(_cartItem);
        OnChange?.Invoke();
        return _cart;
    }
}