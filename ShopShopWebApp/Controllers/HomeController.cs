using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopShopWebApp.Models;
using System.Diagnostics;
using Business_logic.DTOs;
using Business_logic.Interfaces;

namespace ShopShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IAdvertisementsService adsService;

		public HomeController(IAdvertisementsService adsService, ILogger<HomeController> logger)
        {
            this.adsService = adsService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.AdvertisementsCount = await adsService.GetCountAds();
            return View(await adsService.GetAllAds());
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
