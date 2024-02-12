using AutoMapper;
using Business_logic.DTOs;
using Business_logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopShopWebApp.Controllers
{
    public class AdvertisementsController : Controller
    {
		private readonly IAdvertisementsService adsService;
        private readonly IMapper mapper;

        public AdvertisementsController(IAdvertisementsService adsService, IMapper mapper)
        {
            this.adsService = adsService;
            this.mapper = mapper;
        }
        private async Task LoadCategories()
        {
			var categoris = await adsService.GetAllCategories();
			ViewBag.Categories = new SelectList(categoris, nameof(CategoryDto.Id), nameof(CategoryDto.Name));
		}
        public async Task<IActionResult> Index()
        {
            return View(await adsService.GetAllAds());
        }
       
        public async Task<IActionResult> Delete(int id)
        {
            await adsService.DeleteAds(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, string? returnUrl)
        {
            AdvertisementDto? advertisement = await adsService.GetAds(id);
            if (advertisement == null)
                return NotFound();

            ViewBag.ReturnUrl = returnUrl;

            return View(advertisement);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdsDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(model);
            }
            await adsService.CreateAds(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var advertisement = await adsService.GetAds(id);
            if (advertisement == null) return NotFound();

            await LoadCategories();
            return View(mapper.Map<EditAdsDto>(advertisement));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditAdsDto model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(model);
            }

            await adsService.EditAds(model);
            return RedirectToAction("Index");
        }
		[HttpGet]
		public async Task<IActionResult> GetAdvertisement(int id)
		{
			var advertisement = await adsService.GetAds(id);
			if (advertisement == null) return NotFound();

			await LoadCategories();
			return Ok(mapper.Map<EditAdsDto>(advertisement));
		}

	}
}
