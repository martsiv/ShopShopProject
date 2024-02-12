namespace Business_logic.DTOs
{
    public class AdvertisementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string City { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int AdvertisementStatusId { get; set; }
        public string? AdvertisementStatusName { get; set; }
        public ICollection<AdvertisePictureDto> AdvertisePictures { get; set; } = new HashSet<AdvertisePictureDto>();
    }
}
