using AutoMapper;
using data_access.data;
using data_access.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopShopWebApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ShopShopWebApp.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public AdvertisementsController(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
        }
        public async Task<IActionResult> Index()
        {
            var products = await context.Advertisements.
                                                        Include(x => x.Category).
                                                        Include(x => x.AdvertisePictures).
                                                        Include(x => x.AdvertisementStatus).
                                                        ToListAsync();

            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Advertisement? advertisement = await context.Advertisements.FirstOrDefaultAsync(adv => adv.Id == id);
            if (advertisement == null) return NotFound();
            context.Advertisements.Remove(advertisement);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, string? returnUrl)
        {
            Advertisement? advertisement = await context.Advertisements.
                                                        Include(x => x.Category).
                                                        Include(x => x.AdvertisePictures).
                                                        FirstOrDefaultAsync(x => x.Id == id);
            if (advertisement == null)
                return NotFound();

            ViewBag.ReturnUrl = returnUrl;
            return View(advertisement);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            LoadCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdsModel model)
        {
            
            var title = model.Title;
            var price = model.Price;
            var description = model.Description;
            var city = model.City;
            var categoryId = model.CategoryId;

            Advertisement ads = new()
            {
                UserId = 1,
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
                foreach (var picture in model.Pictures.Select((value, i) => new {i, value}))
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
                    if (picture.i == 0)
                        await context.AdvertisePictures.AddAsync(new() { IsMainPicture = true, URL = $"/images/{fileName}", Advertisement = ads });
                    else await context.AdvertisePictures.AddAsync(new() { IsMainPicture = false, URL = $"/images/{fileName}", Advertisement = ads });
                }
            }
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var advertisement = await context.Advertisements.FindAsync(id);
            if (advertisement == null) return NotFound();

            LoadCategories();
            return View(advertisement);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Advertisement model)
        {
            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(model);
            }

            // update product in the db
            context.Advertisements.Update(model);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
