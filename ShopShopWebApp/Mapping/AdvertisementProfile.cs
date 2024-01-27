using AutoMapper;
using data_access.Entities;
using ShopShopWebApp.Models;

namespace ShopShopWebApp.Mapping
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<CreateAdsModel, Advertisement>().ReverseMap(); 
        }
    }
}
