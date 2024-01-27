using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class AdvertisePicture
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement? Advertisement { get; set; }
        public bool IsMainPicture { get; set; }
    }
}
