using AutoMapper;
using HotelManagement.DbContext;
using HotelManagement.Entities;
using HotelManagement.Models;
using HotelManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class TypeServices : ITypeService
    {
        private readonly HotelManagementDbContext _context;

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRoles> _roleManager;
        private readonly IConfiguration _configuration;

        public TypeServices(HotelManagementDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppUserRoles> roleManager,
        IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<int> AddType(TypeModel type)
        {
            Entities.Type Type = _mapper.Map<Entities.Type>(type);
            Type.Id = Guid.NewGuid();
            await _context.Type.AddAsync(Type);
            int i = await _context.SaveChangesAsync();
            return i;
        }

        public async Task<int> DeleteType(Guid typeId)
        {
            var type = _context.Type.FirstOrDefault(e => e.Id == typeId);
             _context.Type.Remove(type);
            int i = await _context.SaveChangesAsync();
            return i; 

        }

        public async Task<IEnumerable<TypeModel>> GetAllTypes()
        {
            var alltypes = await _context.Type.ToListAsync();
            return _mapper.Map<IEnumerable<TypeModel>>(alltypes);
        }

        public async Task<int> UpdateType(TypeModel type)
        {
           var Type = await _context.Type.FirstOrDefaultAsync(e => e.Id == type.Id);
           Type.Name = type.Name;
           int i =  await _context.SaveChangesAsync();
           return i;
        }
    }
}
