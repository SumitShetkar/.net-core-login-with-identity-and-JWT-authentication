using HotelManagement.Entitties;
using HotelManagement.Models;
using AutoMapper;

namespace HotelManagement.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserModel>();
            CreateMap<AppUserModel, AppUser>();
            CreateMap<AppUserRoles, AppUserRolesModel>();
            CreateMap<AppUserRolesModel, AppUserRoles>();
        }
          
    }
}
