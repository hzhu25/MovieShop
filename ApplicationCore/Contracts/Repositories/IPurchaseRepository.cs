using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetById(int userId);
        Task<Purchase> AddPurchase(Purchase purchase);
        Task<bool> CheckIfPurchaseExists(int userId, int movieId);
        Task<Purchase> FindMovieByUserId(int movieId, int userId);
    }
}

