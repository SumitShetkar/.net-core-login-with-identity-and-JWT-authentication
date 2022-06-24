using AutoMapper;
using HotelManagement.DbContext;
using HotelManagement.Entities;
using HotelManagement.Models;
using HotelManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class ItemService : IItemService
    {

        private readonly HotelManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRoles> _roleManager;
        private readonly IConfiguration _configuration;

        public ItemService(HotelManagementDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppUserRoles> roleManager,
          IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        public async Task<int> AddItem(ItemsModel item)
        {
            Item iTem = _mapper.Map<Item>(item);
            iTem.Id = Guid.NewGuid();
            await _context.Items.AddAsync(iTem);
            int i = await _context.SaveChangesAsync();
            return i;
        }

        public async Task<int> DeleteItem(Guid itemId)
        {
            var item = await _context.Items.FirstOrDefaultAsync(e => e.Id == itemId);
            if (item != null)
            {
                _context.Items.Remove(item);
                int i = await _context.SaveChangesAsync();
                return i;

            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<ItemsModel>> GetAllItems()
        {
            try
            {
                var item = await _context.Items.Include(o => o.Type).Include(p => p.Category).ToListAsync();
                return _mapper.Map<IEnumerable<ItemsModel>>(item);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ItemsModel>();
            }
        }

        public async Task<ItemsModel> GetItemById(Guid itemId)
        {
            try
            {
                var result = await _context.Items.Include(o => o.TypeId).Include(o => o.CategoryId).FirstOrDefaultAsync(e => e.Id == itemId);
                return _mapper.Map<ItemsModel>(result);
            }
            catch (Exception ex)
            {
                return new ItemsModel();
            }
        }

        public async Task<int> UpdateItem(ItemsModel item)
        {
            var item1 = await _context.Items.Include(o => o.TypeId).Include(o => o.CategoryId).FirstOrDefaultAsync(e => e.Id == item.Id);
            if (item1 != null)
            {
                item1.Name = item.Name;
                item1.TypeId = item.TypeId;
                item1.CategoryId = item.CategoryId;
                item1.Price = item.Price;
                item1.AddedOn = DateTime.Now;
                _context.Items.Update(item1);
                int i = await _context.SaveChangesAsync();
                return i;
            }
            else
            {
                return 0;
            }
        }
    }
}
