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
		public async Task<IActionResult> Index(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View(_favoritesService.GetAdvertisements());
		}
		public IActionResult Add(int id, string returnUrl)
		{
			_favoritesService.Add(id);
			return Redirect(returnUrl);
		}

		public IActionResult Remove(int id, string returnUrl)
		{
			_favoritesService.Remove(id);
			return Redirect(returnUrl);
		}
	}
}
