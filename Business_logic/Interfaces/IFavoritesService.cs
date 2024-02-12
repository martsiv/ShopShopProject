using Business_logic.DTOs;

namespace Business_logic.Interfaces
{
	public interface IFavoritesService
	{
		IEnumerable<AdvertisementDto> GetAdvertisements();
		void Add(int id);
		void Remove(int id);
		int GetCount();
        bool IsExists(int id);
    }
}
