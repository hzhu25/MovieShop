using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;
        public PurchaseRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }

        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            _movieShopDbContext.Purchases.Add(purchase);
            await _movieShopDbContext.SaveChangesAsync();
            return purchase;
        }

        public async Task<bool> CheckIfPurchaseExists(int userId, int movieId)
        {
            var purchase = await _movieShopDbContext.Purchases
                .Where(p => p.UserId == userId && p.MovieId == movieId)
                .FirstOrDefaultAsync();
            return purchase != null;
        }

        public async Task<List<Purchase>> GetById(int userId)
        {
            var purchase = await _movieShopDbContext.Purchases
                .Where(p => p.UserId == userId)
                .Include(p => p.Movie)
                .ToListAsync();
            return purchase;
        }

        public async Task<Purchase> FindMovieByUserId(int movieId, int userId)
        {
            var purchase = await _movieShopDbContext.Purchases
                .Where(p => p.UserId == userId && p.MovieId == movieId)
                .Include(p => p.Movie).FirstOrDefaultAsync();
            return purchase;
        }
    }
}

