﻿using AutoMapper;
using Business_logic.DTOs;
using Business_logic.Interfaces;
using data_access.data;
using data_access.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Business_logic.Services
{
    public class AdvertisementsService : IAdvertisementsService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper mapper;
        private readonly ApplicationContext context;
        public AdvertisementsService(IMapper mapper, ApplicationContext context, SignInManager<User> signInManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.context = context;
			this._signInManager = signInManager;
			this._userManager = userManager;
			this._httpContextAccessor = httpContextAccessor;
        }
        public async Task CreateAds(CreateAdsDto model)
        {
			var title = model.Title;
			var price = model.Price;
			var description = model.Description;
			var city = model.City;
			var categoryId = model.CategoryId;
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			// Перевіряємо, чи userId не порожній та чи користувач існує в базі даних
			if (userId != null)
			{
				var user = await _userManager.FindByIdAsync(userId);
				if (user == null) return;
			}
			else return;

            Advertisement ads = new()
			{
				UserId = userId,
				AdvertisementStatusId = 2,
				Title = title,
				Price = price,
				Description = description,
				City = city,
				CategoryId = categoryId,
			};
			await context.Advertisements.AddAsync(ads);

			if (model.Pictures != null && model.Pictures.Count > 0)
			{
				foreach (var picture in model.Pictures.Select((value, i) => new { i, value }))
				{
					var fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.value.FileName);

					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
					//Check directory
					var directoryPath = Path.GetDirectoryName(filePath);
					if (!Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
					}

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await picture.value.CopyToAsync(stream);
					}
					if (picture.i == 0) // if index == 0
						await context.AdvertisePictures.AddAsync(new() { IsMainPicture = true, URL = $"/images/{fileName}", Advertisement = ads });
					else await context.AdvertisePictures.AddAsync(new() { IsMainPicture = false, URL = $"/images/{fileName}", Advertisement = ads });
				}
			}
			await context.SaveChangesAsync();
		}

        public async Task DeleteAds(int id)
        {
			var ads = context.Advertisements.Find(id);
			if (ads == null) throw new Exception($"Advertisement with ID {id} not found.");
			// TODO delete pictures also
			context.Advertisements.Remove(ads);
			context.SaveChanges();
		}

        public async Task EditAds(EditAdsDto model)
        {
			var ads = await context.Advertisements.FirstOrDefaultAsync(x => x.Id == model.Id);
			if (ads == null) throw new Exception($"Advertisement with ID {model.Id} not found.");

			ads.Title = model.Title;
			ads.Price = model.Price;
			ads.Description = model.Description;
			ads.City = model.City;
			ads.CategoryId = model.CategoryId;
			ads.AdvertisementStatusId = model.AdvertisementStatusId;

			// Delete previous pictures
			foreach (var adsPicture in model.DeletedAdvertisePicturesUrls)
			{
				if (adsPicture == null) continue;

				// Отримання фізичного шляху до каталогу wwwroot
				string rootPath = Directory.GetCurrentDirectory(); // Поточний каталог

				// Повний шлях до файлу
				string fullPath = Path.Combine(rootPath, "wwwroot", adsPicture.TrimStart('/'));

				//Check directory
				var directoryPath = Path.GetDirectoryName(fullPath);
				if (!Directory.Exists(directoryPath))
					break;
				//Delete picture from storage
				try
				{
					// Check if file exist
					if (File.Exists(fullPath))
					{
						// Delete file
						File.Delete(fullPath);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred when trying to delete a file: {ex.Message}"); // TO DO Throw exeption outside
				}
				
				//Delete drom DB
				var pictureEntity = await context.AdvertisePictures.FirstOrDefaultAsync(x => x.URL == adsPicture);
				if (pictureEntity == null) return; // TODO: throw exceptions
				context.AdvertisePictures.Remove(pictureEntity);
			}
			// Add new pictures
			if (model.NewAdvertisePictures != null && model.NewAdvertisePictures.Count > 0)
			{
				foreach (var picture in model.NewAdvertisePictures.Select((value, i) => new { i, value }))
				{
					var fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.value.FileName);

					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
					//Check directory
					var directoryPath = Path.GetDirectoryName(filePath);
					if (!Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
					}

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await picture.value.CopyToAsync(stream);
					}
					// !!!! need attention, TODO create choosing main pocture
					if (picture.i == 0) 
						await context.AdvertisePictures.AddAsync(new() { IsMainPicture = true, URL = $"/images/{fileName}", Advertisement = ads });
					else await context.AdvertisePictures.AddAsync(new() { IsMainPicture = false, URL = $"/images/{fileName}", Advertisement = ads });
				}
			}


			// update product in the db
			context.Advertisements.Update(ads);
			await context.SaveChangesAsync();
		}
		public async Task<DeliveryDto> GetDeliveryByAds(int id)
		{
			var delivery = await context.DeliveryContactInfos.Include(x => x.DeliveryCompany)
										.Include(x => x.DeliveryHomeAdrdess)
										.FirstOrDefaultAsync(i => i.Id == id);
			if (delivery == null) return null;

			return mapper.Map<DeliveryDto>(delivery);
		}

        public async Task<IEnumerable<AdvertisementDto>> GetAds(IEnumerable<int> ids)
        {
			return mapper.Map<List<AdvertisementDto>>(await context.Advertisements
							.Include(x => x.Category)
                            .Include(x => x.AdvertisePictures)
                            .Include(x => x.User)
                            .Include(x => x.AdvertisementStatus)
							.Where(x => ids.Contains(x.Id))
							.ToListAsync());
		}

        public async Task<AdvertisementDto?> GetAds(int id)
        {
           var ads = await context.Advertisements.Include(x => x.Category)
							.Include(x => x.AdvertisePictures)
							.Include(x => x.User)
							.Include(x => x.AdvertisementStatus)
                            .FirstOrDefaultAsync(i => i.Id == id);
			if (ads == null) return null;

			return mapper.Map<AdvertisementDto>(ads);
		}

        public async Task<IEnumerable<AdvertisementDto>> GetAllAds()
        {
			var adsList = await context.Advertisements
							.Include(x => x.Category)
							.Include(x => x.AdvertisePictures)
                            .Include(x => x.User)
                            .Include(x => x.AdvertisementStatus)
                            .ToListAsync();
			return mapper.Map<List<AdvertisementDto>>(adsList);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
			return mapper.Map<List<CategoryDto>>(await context.Categories.ToListAsync());
		}

		public async Task<int> GetCountAds()
        {
			return context.Advertisements.Count();
		}
	}
}
