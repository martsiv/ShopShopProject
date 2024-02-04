using Business_logic.DTOs;

namespace Business_logic.Interfaces
{
	public interface IAdvertisementsService
	{
		Task<IEnumerable<AdvertisementDTO>> GetAllAds();
		Task<IEnumerable<AdvertisementDTO>> GetAds(IEnumerable<int> ids);
		Task<AdvertisementDTO?> GetAds(int id);
		Task<int> GetCountAds();
		Task<IEnumerable<CategoryDTO>> GetAllCategories();
		Task CreateAds(CreateAdsDTO model);
		Task EditAds(EditAdsDTO model);
		Task DeleteAds(int id);
		Task<DeliveryDTO?> GetDelivery(int AdsID);
		Task EditDelivery(DeliveryDTO model);
	}
}
