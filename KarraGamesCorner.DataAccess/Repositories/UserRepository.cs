using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories;

public class UserRepository(KarraGameCornerDbContext context) : IUserRepository
{
    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await context.Users.Include(user => user.Cart).Include(user => user.Reviews).Include(user => user.WishLists).FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await context.Users.Include(user => user.Cart).Include(user => user.Reviews).Include(user => user.WishLists).FirstOrDefaultAsync(u => u.Email == email);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<User> GetUserByAliasAsync(string alias)
    {
        var user = await context.Users.Include(user => user.Cart).Include(user => user.Reviews).Include(user => user.WishLists).FirstOrDefaultAsync(u => u.Alias == alias);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await context.Users.Include(user => user.Cart).Include(user => user.Reviews).Include(user => user.WishLists).ToListAsync();
    }

    public async Task<Cart> GetCartByUserIdAsync(int userId)
    {
        var user = await context.Users.Include(user => user.Cart).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user.Cart;
    }

    public async Task<List<Review>> GetReviewsByUserIdAsync(int userId)
    {
        var user = await context.Users.Include(user => user.Reviews).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user.Reviews;
    }

    public async Task<List<WishList>> GetWishListsByUserIdAsync(int userId)
    {
        var user = await context.Users.Include(user => user.WishLists).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user.WishLists;
    }

    public async Task AddUserAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(int id, User user)
    {
        var userToUpdate = await context.Users.FindAsync(id);
        if (userToUpdate is null)
        {
            throw new Exception("User not found");
        }

        userToUpdate.Email = user.Email;
        userToUpdate.PhoneNumber = user.PhoneNumber;
        userToUpdate.Password = user.Password;
        userToUpdate.Alias = user.Alias;
        userToUpdate.Address = user.Address;
        userToUpdate.WishLists = user.WishLists;
        userToUpdate.Reviews = user.Reviews;
        userToUpdate.Cart = user.Cart;
        userToUpdate.IsAdmin = user.IsAdmin;

        await context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task AddReviewToUserAsync(int userId, int reviewId)
    {
        var user = await context.Users.Include(user => user.Reviews).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var review = await context.Reviews.FindAsync(reviewId);
        if (review is null)
        {
            throw new Exception("Review not found");
        }

        user.Reviews.Add(review);
        await context.SaveChangesAsync();
    }

    public async Task RemoveReviewFromUserAsync(int userId, int reviewId)
    {
        var user = await context.Users.Include(user => user.Reviews).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var review = await context.Reviews.FindAsync(reviewId);
        if (review is null)
        {
            throw new Exception("Review not found");
        }

        user.Reviews.Remove(review);
        await context.SaveChangesAsync();
    }

    public async Task AddWishListToUserAsync(int userId, int wishListId)
    {
        var user = await context.Users.Include(user => user.WishLists).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var wishList = await context.WishLists.FindAsync(wishListId);
        if (wishList is null)
        {
            throw new Exception("WishList not found");
        }

        user.WishLists.Add(wishList);
        await context.SaveChangesAsync();
    }

    public async Task RemoveWishListFromUserAsync(int userId, int wishListId)
    {
        var user = await context.Users.Include(user => user.WishLists).FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var wishList = await context.WishLists.FindAsync(wishListId);
        if (wishList is null)
        {
            throw new Exception("WishList not found");
        }

        user.WishLists.Remove(wishList);
        await context.SaveChangesAsync();
    }
}