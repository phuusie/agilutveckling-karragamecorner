using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IReviewRepository
{
    Task<List<Review>> GetAllReviewsAsync();
    Task AddReviewAsync(Review review);
    Task RemoveReviewAsync(int id);
}