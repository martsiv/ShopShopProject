using Business_logic.Interfaces;
using ShopShopWebApp.Services;

namespace ShopShopWebApp.Helpers
{
	public static class ServiceExtensions
	{
		public static void AddFavoriteService(this IServiceCollection services)
		{
			services.AddScoped<IFavoritesService, FavoritesService>();
		}
	}
}
