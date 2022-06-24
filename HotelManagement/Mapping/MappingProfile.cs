
using HotelManagement.Models;
using AutoMapper;
using HotelManagement.Entities;

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
            CreateMap<TablesModel, Table>();
            CreateMap<Table, TablesModel>();
            CreateMap<Type, TypeModel>();
            CreateMap<TypeModel, Type>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
            CreateMap<Item, ItemsModel>();
            CreateMap<ItemsModel, Item>();
        }
          
    }
}
