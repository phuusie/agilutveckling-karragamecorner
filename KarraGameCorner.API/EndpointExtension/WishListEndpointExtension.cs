using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension
{
    public static class WishListEndpointExtension
    {
        public static IEndpointRouteBuilder MapWishListEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/wishlist");

            group.MapGet("", GetAllWishLists);

            group.MapPut("", UpdateWihList);

            return app;
        }

        private static async Task<IEnumerable<WishList>> GetAllWishLists(IWishListRepository repo)
        {
            return await repo.GetAllWishListsAsync();
        }

        private static Task UpdateWihList(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
