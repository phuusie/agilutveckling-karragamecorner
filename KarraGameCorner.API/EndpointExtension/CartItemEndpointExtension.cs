using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension;

public static class CartItemEndpointExtension
{
    public static IEndpointRouteBuilder MapCartItemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/cartItems");

        group.MapGet("/", GetAllCartItems);
        group.MapPost("/", AddCartItem);
        group.MapDelete("/{id:int}", DeleteCartItem);

        return app;
    }

    private static Task<List<CartItem>> GetAllCartItems(ICartItemRepository repo)
    {
        return repo.GetAllCartItemsAsync();
    }

    private static Task DeleteCartItem(ICartItemRepository repo, int id)
    {
        return repo.DeleteCartItemAsync(id);
    }

    private static Task AddCartItem(ICartItemRepository repo, CartItem cartItem)
    {
        return repo.AddCartItemAsync(cartItem);
    }

}