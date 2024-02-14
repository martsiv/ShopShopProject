using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.DTOs
{
    public class OrderDto
    {
        // TODO Change DTO
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementDto? Advertisement { get; set; }
        public int DeliveryContactInfoId { get; set; }
        public DeliveryContactInfo? DeliveryContactInfo { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
