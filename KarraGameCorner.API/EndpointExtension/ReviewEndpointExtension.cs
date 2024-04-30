using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;

namespace KarraGameCorner.API.EndpointExtension
{
    public static class ReviewEndpointExtension
    {
        public static IEndpointRouteBuilder MapReviewEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/review");

            group.MapGet("", GetAllReviews);

            group.MapPost("/{userId:int}/{prodId:int}", PostReview);

            group.MapDelete("/{id:int}", DeleteReview);

            return app;
        }

        private static async Task<IEnumerable<Review>> GetAllReviews(IReviewRepository repo)
        {
            return await repo.GetAllReviewsAsync();
        }

        private static async Task PostReview(IReviewRepository repo, Review review)
        {
            await repo.AddReviewAsync(review);
        }

        private static async Task DeleteReview(IReviewRepository repo, int id)
        {
            await repo.RemoveReviewAsync(id);
        }
    }
}
