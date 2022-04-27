﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
