using KarraGameCorner.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess;

public class KarraGameCornerDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<Event> Events { get; set; }
}