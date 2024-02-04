using Business_logic.DTOs;
using data_access.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ShopShopWebApp.Controllers
{
	public class AdministrationController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{

			
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Details(int id, string? returnUrl)
		{
			
			return View();
		}
		
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Advertisement model)
		{

			return RedirectToAction("Index");
		}
	}
}
