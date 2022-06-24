using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();

        Task<int> AddCategory(CategoryModel category);

        Task<int> UpdateCategory(CategoryModel category);

        Task<int> DeleteCategoy(Guid categoryId);

        Task<CategoryModel> GetCategoryId(Guid categoryId);
    }
}
