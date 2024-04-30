using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IOrderItemRepository
{
    Task AddOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(int id);
    Task<List<OrderItem>> GetAllOrderItemsAsync();
}