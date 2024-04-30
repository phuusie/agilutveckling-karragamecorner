using KarraGameCorner.DataAccess.Entities;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories
{
    public class ReviewRepository(KarraGameCornerDbContext context) : IReviewRepository
    {
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await context.Reviews.ToListAsync();
        }
        public async Task AddReviewAsync(Review review)
        {
            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }

        public async Task RemoveReviewAsync(int id)
        {
            var review = await context.Reviews.FindAsync(id);

            if (review is null)
            {
                return;
            }

            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
        }

    }
}
