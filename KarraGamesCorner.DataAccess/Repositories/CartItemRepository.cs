using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class CartItemRepository(KarraGameCornerDbContext context) : ICartItemRepository
{
    public async Task AddCartItemAsync(CartItem cartItem)
    {
        await context.CartItems.AddAsync(cartItem);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCartItemAsync(int id)
    {
        var cartItem = await context.CartItems.FindAsync(id);
        if (cartItem is null)
        {
            throw new Exception("Cart item not found");
        }
        context.CartItems.Remove(cartItem);
        await context.SaveChangesAsync();
    }
    public async Task<List<CartItem>> GetAllCartItemsAsync()
    {
        return await context.CartItems.ToListAsync();
    }   
}