using Business_logic.Interfaces;
using Business_logic.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace Business_logic
{
	public static class ServiceExtensions
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}
		public static void AddFluentValidator(this IServiceCollection services)
		{
			services.AddFluentValidationAutoValidation();
			// enable client-side validation
			services.AddFluentValidationClientsideAdapters();
			// Load an assembly reference rather than using a marker type.
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
		}
		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddScoped<IAdvertisementsService, AdvertisementsService>();
			// others...
		}
	}
}
