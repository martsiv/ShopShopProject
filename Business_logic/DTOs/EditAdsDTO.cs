using data_access.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.DTOs
{
    public class EditAdsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public int AdvertisementStatusId { get; set; }
        public string? AdvertisementStatusName { get; set; }
        public ICollection<AdvertisePictureDto> AdvertisePictures { get; set; } = new HashSet<AdvertisePictureDto>();
        public ICollection<string> DeletedAdvertisePicturesUrls { get; set; } = new List<string>();
        public List<IFormFile> NewAdvertisePictures { get; set; } = new List<IFormFile>();
    }
}
