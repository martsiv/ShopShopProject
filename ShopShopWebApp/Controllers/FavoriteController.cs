using Microsoft.AspNetCore.Mvc;
using Business_logic.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ShopShopWebApp.Controllers
{
	public class FavoriteController : Controller
	{
		private readonly IFavoritesService _favoritesService;
        public FavoriteController(IFavoritesService favoritesService)
        {
            this._favoritesService = favoritesService;
        }
		public async Task<IActionResult> Index()
		{
			return View(_favoritesService.GetAdvertisements());
		}
		public IActionResult Add(int id)
		{
			_favoritesService.Add(id);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(int id)
		{
			_favoritesService.Remove(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
