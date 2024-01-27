using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class AdvertisementStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();

    }
}
