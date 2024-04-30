using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(int id);
    Task<List<Order>> GetAllOrdersAsync();
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(int id, Order order);
    Task DeleteOrderAsync(int id);
    Task<List<Order>> GetOrdersByEmailAsync(string email);
}