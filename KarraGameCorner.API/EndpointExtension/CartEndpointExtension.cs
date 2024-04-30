using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;

namespace KarraGameCorner.API.EndpointExtension;

public static class CartEndpointExtension
{
    public static IEndpointRouteBuilder MapCartEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/carts");

        group.MapGet("/", GetAllCarts);
        group.MapGet("/{id:int}", GetCartById);
        group.MapPost("/", AddCart);
        group.MapPut("/{id:int}", UpdateCart);
        group.MapDelete("/{id:int}", DeleteCart);
        group.MapPost("/{id:int}", AddCartItemToCart);
        group.MapPatch("/{id:int}", RemoveCartItemFromCart);

        return app;
    }

    private static Task RemoveCartItemFromCart(ICartRepository repo, int id, int cartItemId)
    {
        return repo.RemoveCartItemFromCartAsync(id, cartItemId);
    }

    private static Task AddCartItemToCart(ICartRepository repo, int id, CartItem cartItem)
    {
        return repo.AddCartItemToCartAsync(id, cartItem);
    }

    private static Task<List<Cart>> GetAllCarts(ICartRepository repo)
    {
        return repo.GetAllCartsAsync();
    }

    private static Task DeleteCart(ICartRepository repo, int id)
    {
        return repo.DeleteCartAsync(id);
    }

    private static Task UpdateCart(ICartRepository repo, Cart cart, int id)
    {
        return repo.UpdateCartAsync(id, cart);
    }

    private static Task AddCart(ICartRepository repo, Cart cart)
    {
        return repo.AddCartAsync(cart);
    }

    private static Task<Cart> GetCartById(ICartRepository repo, int id)
    {
        return repo.GetCartByIdAsync(id);
    }

}