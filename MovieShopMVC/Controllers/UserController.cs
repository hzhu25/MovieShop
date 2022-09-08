using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Infra;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserService _userService;
        private readonly IPurchaseRepository _purchaseRepository;
        public UserController(ICurrentUser currentUser, IPurchaseRepository purchaseRepository, IUserService userService)
        {
            _purchaseRepository = purchaseRepository;
            _userService = userService;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            var userId = _currentUser.UserId;
            var movies = await _userService.GetAllPurchasesForUser(userId);
            return View(movies);
        }


        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            var userId = _currentUser.UserId;
            PurchaseRequestModel model = new PurchaseRequestModel
            {
                MovieId = movieId,
                UserId = userId
            };

            var purchases = await _userService.PurchaseMovie(model, userId);

            return RedirectToAction("Details", "Movies", new { id = movieId });
        }
        [HttpPost]
        public async Task<IActionResult> FavoriteMovie()
        {
            return View();
        }
    }
}