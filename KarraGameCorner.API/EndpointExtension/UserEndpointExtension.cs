using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension
{
    public static class UserEndpointExtension
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/users");

            group.MapGet("", GetUsers);

            group.MapGet("/{id:int}", GetUserById);

            group.MapGet("/{email}", GetUserByEmail);

            group.MapGet("/{alias}", GetUserByAlias);

            group.MapGet("/cart/{userId:int}", GetCartByUserId);

            group.MapGet("/reviews/{userId:int}", GetReviewsById);

            group.MapGet("/wishlist/{userId:int}", GetWishListById);

            group.MapPost("", PostCustomer);

            group.MapPost("/review", PostReviewToCustomer);

            group.MapPost("/wishlist", PostWishListToCustomer);

            group.MapPut("", UpdateUser);

            group.MapDelete("/{id}", DeleteUser);

            group.MapDelete("/review/{id}", RemoveReviewFromUser);

            group.MapDelete("/wishlist/[{id}", RemoveWishListFromUser);

            return app;
        }

        private static async Task<IEnumerable<User>> GetUsers(IUserRepository repo)
        {
            return await repo.GetAllUsersAsync();
        }
        private static async Task<User> GetUserById(IUserRepository repo, int id)
        {
            return await repo.GetUserByIdAsync(id);
        }

        private static async Task<User> GetUserByEmail(IUserRepository repo, string email)
        {
            return await repo.GetUserByEmailAsync(email);
        }

        private static async Task<User> GetUserByAlias(IUserRepository repo, string alias)
        {
            return await repo.GetUserByAliasAsync(alias);
        }

        private static async Task<Cart> GetCartByUserId(IUserRepository repo, int userId)
        {
            return await repo.GetCartByUserIdAsync(userId);
        }

        private static async Task<IEnumerable<Review>> GetReviewsById(IUserRepository repo, int userId)
        {
            return await repo.GetReviewsByUserIdAsync(userId);
        }

        private static async Task<IEnumerable<WishList>> GetWishListById(IUserRepository repo, int userId)
        {
            return await repo.GetWishListsByUserIdAsync(userId);
        }

        private static async Task PostCustomer(IUserRepository repo, User user)
        {
            await repo.AddUserAsync(user);
        }

        private static async Task PostReviewToCustomer(IUserRepository repo, int userId, int reviewId)
        {
            await repo.AddReviewToUserAsync(userId, reviewId);
        }

        private static async Task PostWishListToCustomer(IUserRepository repo, int userId, int wishListId)
        {
            await repo.AddWishListToUserAsync(userId, wishListId);
        }

        private static async Task UpdateUser(IUserRepository repo, User user, int id)
        {
            await repo.UpdateUserAsync(id, user);
        }
        private static async Task DeleteUser(IUserRepository repo, int id)
        {
            await repo.DeleteUserAsync(id);
        }

        private static async Task RemoveReviewFromUser(IUserRepository repo, int id, int userId)
        {
            await repo.RemoveReviewFromUserAsync(id, userId);
        }

        private static async Task RemoveWishListFromUser(IUserRepository repo, int id, int userId)
        {
            await repo.RemoveWishListFromUserAsync(id, userId);
        }

    }
}
