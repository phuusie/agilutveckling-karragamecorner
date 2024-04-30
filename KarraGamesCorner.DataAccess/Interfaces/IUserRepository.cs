using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByAliasAsync(string alias);
    Task<List<User>> GetAllUsersAsync();
    Task<Cart> GetCartByUserIdAsync(int userId);
    Task<List<Review>> GetReviewsByUserIdAsync(int userId);
    Task<List<WishList>> GetWishListsByUserIdAsync(int userId);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(int id, User user);
    Task DeleteUserAsync(int id);
    Task AddReviewToUserAsync(int userId, int reviewId);
    Task RemoveReviewFromUserAsync(int userId, int reviewId);
    Task AddWishListToUserAsync(int userId, int wishListId);
    Task RemoveWishListFromUserAsync(int userId, int wishListId);
}