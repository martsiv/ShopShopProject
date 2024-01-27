using data_access.Entities;

namespace ShopShopWebApp.Models
{
    public class CreateAdsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string City { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> Pictures { get; set; } = new List<IFormFile>();
    }
}
