using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class CartRepository(KarraGameCornerDbContext context) : ICartRepository
{
    public async Task AddCartAsync(Cart cart)
    {
        if (await context.Carts.AnyAsync(c => c.Id == cart.Id))
        {
            throw new Exception("Cart already exists");
        }
        await context.Carts.AddAsync(cart);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCartAsync(int id)
    {
        var cart = await context.Carts.FindAsync(id);
        if (cart is null)
        {
            throw new Exception("Cart not found");
        }
        context.Carts.Remove(cart);
        await context.SaveChangesAsync();
    }

    public async Task AddCartItemToCartAsync(int id, CartItem cartItem)
    {
        var cart = await context.Carts.FindAsync(id);
        if (cart is null)
        {
            throw new Exception("Cart not found");
        }

        cart.Products.Add(cartItem);
        await context.SaveChangesAsync();
    }

    public async Task RemoveCartItemFromCartAsync(int id, int cartItemId)
    {
        var cart = await context.Carts.Include(c => c.Products).SingleOrDefaultAsync(c => c.Id == id);
        if (cart is null)
        {
            throw new Exception("Cart not found");
        }
        var cartItem = cart.Products.FirstOrDefault(c => c.Id == cartItemId);
        if (cartItem is null)
        {
            throw new Exception("Cart item not found");
        }
        cart.Products.Remove(cartItem);
        await context.SaveChangesAsync();
    }

    public async Task<List<Cart>> GetAllCartsAsync()
    {
        return await context.Carts.ToListAsync();
    }

    public async Task<Cart> GetCartByIdAsync(int id)
    {
        var cart = await context.Carts.FindAsync(id);
        if (cart is null)
        {
            throw new Exception("Cart not found");
        }
        return cart;
    }

    public async Task UpdateCartAsync(int id, Cart cart)
    {
        var existingCart = await context.Carts.FindAsync(id);
        if (existingCart is null)
        {
            throw new Exception("Cart not found");
        }

        existingCart.Products = cart.Products;
        await context.SaveChangesAsync();
    }
}