using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension;

public static class OrderItemEndpointExtension
{
    public static IEndpointRouteBuilder MapOrderItemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orderItems");

        group.MapGet("/", GetAllOrderItems);
        group.MapPost("/", AddOrderItem);
        group.MapDelete("/{id:int}", DeleteOrderItem);

        return app;
    }

    private static Task<List<OrderItem>> GetAllOrderItems(IOrderItemRepository repo)
    {
        return repo.GetAllOrderItemsAsync();
    }

    private static Task DeleteOrderItem(IOrderItemRepository repo, int id)
    {
        return repo.DeleteOrderItemAsync(id);
    }

    private static Task AddOrderItem(IOrderItemRepository repo, OrderItem orderItem)
    {
        return repo.AddOrderItemAsync(orderItem);
    }
}