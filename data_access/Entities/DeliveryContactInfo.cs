using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class DeliveryContactInfo
    {
        public int Id { get; set; }
        public int DeliveryCompanyId { get; set; }
        public DeliveryCompany? DeliveryCompany { get; set; }
        public int? DeliveryHomeAddressId { get; set; }
        public DeliveryHomeAdrdess? DeliveryHomeAdrdess { get; set; }
        public Order? Order { get; set; }
        public string City { get; set; }
        public string? PostOffice { get; set; }

    }
}
