using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class DeliveryHomeAdrdess
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Build { get; set; }
        public string? Appartment { get; set; }
        public string? ExtraInfoForCourier { get; set; }
        public ICollection<DeliveryContactInfo> DeliveryContactInfos { get; set; } = new HashSet<DeliveryContactInfo>();
    }
}
