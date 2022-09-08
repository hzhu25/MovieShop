using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> GetById(int userId, int movieId);
        Task<Review> ReviewAdd(Review review);
        Task<Review> ReviewRemove(Review review);
        Task<Review> ReviewUpdate(Review review);
        Task<bool> CheckIfReviewExists(int userId, int movieId);
    }
}

