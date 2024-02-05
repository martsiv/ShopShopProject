using data_access.Entities;
using AutoMapper;
using Business_logic.DTOs;

namespace Business_logic.Mapping
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementDTO>();
            CreateMap<Advertisement, EditAdsDTO>();

            CreateMap<AdvertisementDTO, EditAdsDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<DeliveryContactInfo, DeliveryDTO>();
            CreateMap<AdvertisePicture, AdvertisePictureDTO>().ReverseMap();
		}
	}
}
