using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class AppUser : IdentityUser
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
