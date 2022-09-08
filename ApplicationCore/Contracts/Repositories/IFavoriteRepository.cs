using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetById(int userId);
        Task<Favorite> FavoriteAdd(Favorite favorite);
        Task<Favorite> FavoriteRemove(Favorite favorite);
        Task<bool> CheckIfFavoriteExists(int userId, int movieId);
    }
}

