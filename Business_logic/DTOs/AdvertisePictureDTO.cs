using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.DTOs
{
    public class AdvertisePictureDTO
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public bool IsMainPicture { get; set; }
    }
}
