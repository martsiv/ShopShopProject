using data_access.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopShopWebApp.Models;
using System.Diagnostics;

namespace ShopShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext context;

        public HomeController(ApplicationContext context, ILogger<HomeController> logger)
        {
            this.context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ProductsCount = context.Advertisements.Count();

            var products = await context.Advertisements.
                                                        Include(x => x.Category).
                                                        Include(x => x.AdvertisePictures).
                                                        Include(x => x.AdvertisementStatus).
                                                        ToListAsync();

            return View(products);
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
