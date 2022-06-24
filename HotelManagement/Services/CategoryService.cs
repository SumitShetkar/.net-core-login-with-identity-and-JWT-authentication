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
    public class CategoryService : ICategoryService
    {
        private readonly HotelManagementDbContext _context;

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRoles> _roleManager;
        private readonly IConfiguration _configuration;

        public CategoryService(HotelManagementDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppUserRoles> roleManager,
        IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        public async Task<int> AddCategory(CategoryModel category)
        {

            var cat = _mapper.Map<Category>(category);
            cat.Id = Guid.NewGuid();
            await _context.Category.AddAsync(cat);
            int i = await _context.SaveChangesAsync();
            return i;

        }

        public async Task<int> DeleteCategoy(Guid categoryId)
        {
            var category = await _context.Category.FirstOrDefaultAsync(e => e.Id == categoryId);
            if (category != null)
            {
                _context.Category.Remove(category);
                int i = await _context.SaveChangesAsync();
                return i;

            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            try
            {
                var catagory = await _context.Category.ToListAsync();
                return _mapper.Map<IEnumerable<CategoryModel>>(catagory);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<CategoryModel>();
            }
        }

        public async Task<CategoryModel> GetCategoryId(Guid categoryId)
        {
            try
            {
                var result = await _context.Category.FirstOrDefaultAsync(e => e.Id == categoryId);
                return _mapper.Map<CategoryModel>(result);
            }
            catch (Exception ex)
            {
                return new CategoryModel();
            }
        }

        public async Task<int> UpdateCategory(CategoryModel category)
        {
            var cat = await _context.Category.FirstOrDefaultAsync(e => e.Id == category.Id);
            var Category = _mapper.Map<Category>(category);

            if (cat != null)
            {
                cat.Name = Category.Name;
                _context.Category.Update(cat);
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










