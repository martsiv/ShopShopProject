using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();


    }
}
