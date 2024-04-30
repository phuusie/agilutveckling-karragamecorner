using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class OrderRepository(KarraGameCornerDbContext context) : IOrderRepository
{
    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await context.Orders.Include(order => order.Products).FirstOrDefaultAsync(o => o.Id == id);
        if (order is null)
        {
            throw new Exception("Order not found");
        }

        return order;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await context.Orders.Include(order => order.Products).ToListAsync();
    }

    public async Task AddOrderAsync(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(int id, Order order)
    {
        var orderToUpdate = await context.Orders.FindAsync(id);
        if (orderToUpdate is null)
        {
            throw new Exception("Order not found");
        }

        orderToUpdate.Products = order.Products;
        orderToUpdate.Email = order.Email;
        orderToUpdate.OrderDate = order.OrderDate;
        orderToUpdate.ShippingAddress = order.ShippingAddress;
        orderToUpdate.TotalPrice = order.TotalPrice;

        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order is null)
        {
            throw new Exception("Order not found");
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetOrdersByEmailAsync(string email)
    {
        return await context.Orders.Include(order => order.Products).Where(o => o.Email == email).ToListAsync();
    }
}