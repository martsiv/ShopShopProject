using data_access.Entities;
using Microsoft.AspNetCore.Http;

namespace Business_logic.DTOs
{
    public class CreateAdsDTO
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
