using HotelManagement.Entitties;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
    public interface IUserService
    {
        public Task<AppUser> Login(UserLoginModel user);
        public Task<bool> Register(AppUserModel user, string roleId);
    }
}
