﻿using Business_logic.DTOs;
using Business_logic.Interfaces;
using ShopShopWebApp.Helpers;
using System.Text.Json;

namespace ShopShopWebApp.Services
{
	public class FavoritesService : IFavoritesService
	{
		const string key = "fav_item_key";
		private readonly HttpContext httpContext;
		private readonly IAdvertisementsService advertisementsService;

		public FavoritesService(IHttpContextAccessor httpContextAccessor, IAdvertisementsService advertisementsService)
		{
			this.httpContext = httpContextAccessor.HttpContext!;
			this.advertisementsService = advertisementsService;
		}
        private void SaveItems(List<int> items)
        {
			//httpContext.Session.SetString(key, JsonSerializer.Serialize(items));
			httpContext.Session.Set(key, items);
		}
        private List<int>? GetItems()
        {
			//var value = httpContext.Session.GetString(key);
			//return value == null ? default : JsonSerializer.Deserialize<List<int>>(value);
			return httpContext.Session.Get<List<int>>(key);
		}
        public int GetCount()
		{
			return GetItems()?.Count ?? 0;
		}

		public void Add(int id)
		{
			// get existing items in the cart
			var ids = GetItems();

			if (ids == null) ids = new();
			ids.Add(id);

			// save items to the cart
			SaveItems(ids);
		}
		public IEnumerable<AdvertisementDto> GetAdvertisements()
		{
			IEnumerable<int> ids = GetItems() ?? Enumerable.Empty<int>();
			return advertisementsService.GetAds(ids).Result;
		}


		public void Remove(int id)
		{
			// get existing items in the cart
			var ids = GetItems();

			if (ids == null) return;
			ids.Remove(id);

			// save items to the cart
			SaveItems(ids);
		}

        public bool IsExists(int id)
        {
            IEnumerable<int>? ids = GetItems();

            if (ids == null) return false;

            return ids.Contains(id);
        }
        public IEnumerable<int> GetAdsIds()
        {
            return GetItems() ?? Enumerable.Empty<int>();
        }
    }
}
