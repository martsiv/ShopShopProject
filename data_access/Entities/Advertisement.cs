using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string City { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public DeliveryContactInfo? DeliveryContactInfo { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int AdvertisementStatusId { get; set; }
        public AdvertisementStatus? AdvertisementStatus { get; set; }
        public ICollection<AdvertisePicture> AdvertisePictures { get; set; } = new HashSet<AdvertisePicture>();
    }
}
