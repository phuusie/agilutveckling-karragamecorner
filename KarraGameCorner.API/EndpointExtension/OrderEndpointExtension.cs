using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension;

public static class OrderEndpointExtension
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("/", GetAllOrders);
        group.MapGet("/{id:int}", GetOrderById);
        group.MapPost("/", AddOrder);
        group.MapPut("/{id:int}", UpdateOrder);
        group.MapDelete("/{id:int}", DeleteOrder);
        group.MapGet("/{email}", GetOrdersByEmail);

        return app;
    }

    private static Task<List<Order>> GetOrdersByEmail(IOrderRepository repo, string email)
    {
        return repo.GetOrdersByEmailAsync(email);
    }

    private static Task DeleteOrder(IOrderRepository repo, int id)
    {
        return repo.DeleteOrderAsync(id);
    }

    private static Task UpdateOrder(IOrderRepository repo, Order order, int id)
    {
        return repo.UpdateOrderAsync(id, order);
    }

    private static Task AddOrder(IOrderRepository repo, Order order)
    {
        return repo.AddOrderAsync(order);
    }

    private static Task<Order> GetOrderById(IOrderRepository repo, int id)
    {
        return repo.GetOrderByIdAsync(id);
    }

    private static Task<List<Order>> GetAllOrders(IOrderRepository repo)
    {
        return repo.GetAllOrdersAsync();
    }
}