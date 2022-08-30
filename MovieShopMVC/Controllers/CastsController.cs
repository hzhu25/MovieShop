using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastsController : Controller
    {
        private readonly ICastService _castService;
        public CastsController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var castDetails = await _castService.GetCastDetails(id);
            return View(castDetails);
        }
    }
}