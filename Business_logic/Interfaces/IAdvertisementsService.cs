using Business_logic.DTOs;

namespace Business_logic.Interfaces
{
	public interface IAdvertisementsService
	{
		Task<IEnumerable<AdvertisementDto>> GetAllAds();
		Task<IEnumerable<AdvertisementDto>> GetAds(IEnumerable<int> ids);
		Task<AdvertisementDto?> GetAds(int id);
		Task<int> GetCountAds();
		Task<IEnumerable<CategoryDto>> GetAllCategories();
		Task CreateAds(CreateAdsDto model);
		Task EditAds(EditAdsDto model);
		Task DeleteAds(int id);
	}
}
