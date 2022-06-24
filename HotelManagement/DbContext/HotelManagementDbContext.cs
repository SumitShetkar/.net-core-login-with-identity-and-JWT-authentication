using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HotelManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using HotelManagement.Models;


namespace HotelManagement.DbContext
{
    public class HotelManagementDbContext : IdentityDbContext<AppUser,AppUserRoles,string>
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext>options) : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppUserRoles> AppUserRoles { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Category { get; set; }
   
        public DbSet<HotelManagement.Entities.Type> Type { get; set; }

      


    }
}
