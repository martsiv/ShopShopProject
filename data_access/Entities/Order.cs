using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement? Advertisement { get; set; }
        public int DeliveryContactInfoId { get; set; }
        public DeliveryContactInfo? DeliveryContactInfo { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
