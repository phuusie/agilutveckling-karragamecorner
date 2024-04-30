using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class OrderItemRepository(KarraGameCornerDbContext context) : IOrderItemRepository
{
    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        await context.OrderItems.AddAsync(orderItem);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        var orderItem = await context.OrderItems.FindAsync(id);
        if (orderItem is null)
        {
            throw new Exception("Order item not found");
        }
        context.OrderItems.Remove(orderItem);
        await context.SaveChangesAsync();
    }

    public async Task<List<OrderItem>> GetAllOrderItemsAsync()
    {
        return await context.OrderItems.ToListAsync();
    }
}