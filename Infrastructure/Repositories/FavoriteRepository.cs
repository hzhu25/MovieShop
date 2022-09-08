using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;
        public FavoriteRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }

        public async Task<Favorite> FavoriteAdd(Favorite favorite)
        {
            _movieShopDbContext.Favorites.Add(favorite);
            await _movieShopDbContext.SaveChangesAsync();
            return favorite;
        }
        public async Task<Favorite> FavoriteRemove(Favorite favorite)
        {
            _movieShopDbContext.Favorites.Remove(favorite);
            await _movieShopDbContext.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> CheckIfFavoriteExists(int userId, int movieId)
        {
            var favorite = await _movieShopDbContext.Favorites
                .Where(f => f.UserId == userId && f.MovieId == movieId)
                .FirstOrDefaultAsync();
            return favorite != null;
        }

        public async Task<List<Favorite>> GetById(int userId)
        {
            var favorites = await _movieShopDbContext.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Movie)
                .ToListAsync();
            return favorites;
        }

    }
}

