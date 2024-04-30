using KarraGameCorner.DataAccess.Entities;

namespace KarraGameCorner.DataAccess.Interfaces;

public interface IWishListRepository
{
    Task<List<WishList>> GetAllWishListsAsync();

    Task AddToWishListAsync();

    Task RemoveFromWishListAsync();
}