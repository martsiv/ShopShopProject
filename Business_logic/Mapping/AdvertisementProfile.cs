using data_access.Entities;
using AutoMapper;
using Business_logic.DTOs;

namespace Business_logic.Mapping
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<Advertisement, EditAdsDto>();

            CreateMap<AdvertisementDto, EditAdsDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<DeliveryContactInfo, DeliveryDto>();
            CreateMap<AdvertisePicture, AdvertisePictureDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

        }
    }
}
