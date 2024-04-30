using KarraGameCorner.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarraGameCorner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner.DataAccess.Repositories
{
    public class WishListRepository(KarraGameCornerDbContext context) : IWishListRepository
    {
        public async Task<List<WishList>> GetAllWishListsAsync()
        {
            return await context.WishLists.ToListAsync();
        }

        public async Task AddToWishListAsync()
        {

        }

        public async Task RemoveFromWishListAsync()
        {

        }
    }
}
