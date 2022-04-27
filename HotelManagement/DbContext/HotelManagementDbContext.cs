using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HotelManagement.Entitties;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagement.DbContext
{
    public class HotelManagementDbContext : IdentityDbContext<AppUser,AppUserRoles,string>
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext>options) : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppUserRoles> AppUserRoles { get; set; }
        
    }
}
