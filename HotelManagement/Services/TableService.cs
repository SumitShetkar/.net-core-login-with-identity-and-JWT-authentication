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
    public class TableService : ITableService
    {
        private readonly HotelManagementDbContext _context;

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRoles> _roleManager;
        private readonly IConfiguration _configuration;
        public TableService(HotelManagementDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppUserRoles> roleManager,
            IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }
        public async Task<int> AddTable(TablesModel Table)
        {
             Table table = _mapper.Map<Table>(Table);
             table.Id = Guid.NewGuid();
             await _context.Tables.AddAsync(table);
             int i = await _context.SaveChangesAsync();
             return i;
        }

        public async Task<int> DeleteTable(Guid tableId)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(e => e.Id == tableId);
            if (table !=null)
            {
                _context.Tables.Remove(table);
                int i = await _context.SaveChangesAsync();
                return i;

            }
            else
            {
                return 0;
            }
          
        }

     

        public async Task<IEnumerable<TablesModel>> GetAllTables()
        {
            try
            {
                var table =await _context.Tables.ToListAsync();
                return _mapper.Map<IEnumerable<TablesModel>>(table);
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<TablesModel>();
            }
      
        }

        public async Task<TablesModel> GetTableById(Guid tableId)
        {
            try
            {
                var result = await _context.Tables.FirstOrDefaultAsync(e => e.Id == tableId);
                return _mapper.Map<TablesModel>(result);
            }
            catch(Exception ex)
            {
                return new TablesModel();
            }   
        }

      

        public async Task<int> UpdateTable(TablesModel tablesModel)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(e => e.Id == tablesModel.Id);
            if (table != null)
            {
                table.Name = tablesModel.Name;
                _context.Tables.Update(table);
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
