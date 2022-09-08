using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public UserService(IPurchaseRepository purchaseRepository, IUserRepository userRepository)
        {
            _purchaseRepository = purchaseRepository;
            _userRepository = userRepository;
        }

        public async Task<List<MovieCardModel>> GetAllPurchasesForUser(int id)
        {
            var purchases = await _purchaseRepository.GetById(id);
            var movieCards = new List<MovieCardModel>();
            foreach (var purchase in purchases)
            {
                movieCards.Add(new MovieCardModel { Id = purchase.MovieId, PosterUrl = purchase.Movie.PosterUrl, Title = purchase.Movie.Title });
            }
            return movieCards;
        }

        public async Task<PurchaseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchase = await _purchaseRepository.FindMovieByUserId(movieId, userId);
            if (purchase == null)
                return null;
            var purchaseDetails = new PurchaseModel
            {
                MovieId = movieId,
                UserId = userId,
                TotalPrice = purchase.TotalPrice,
                PurchaseDateTime = purchase.PurchaseDateTime,
                PurchaseNumber = purchase.PurchaseNumber
            };
            return purchaseDetails;
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            if (await _purchaseRepository.CheckIfPurchaseExists(userId, purchaseRequest.MovieId))
                return true;
            return false;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            var newPurchase = new Purchase
            {
                MovieId = purchaseRequest.MovieId,
                UserId = userId,
                TotalPrice = purchaseRequest.Price,
                PurchaseDateTime = purchaseRequest.PurchaseDateTime,
                PurchaseNumber = purchaseRequest.PurchaseNumber
            };

            var savedPurchase = await _purchaseRepository.AddPurchase(newPurchase);
            if (savedPurchase.Id > 1)
            {
                return true;
            }
            return false;
        }
    }
}

