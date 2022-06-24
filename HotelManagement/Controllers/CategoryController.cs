using HotelManagement.Models;
using HotelManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
    }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
           var result = await _categoryservice.GetAllCategories();
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Tables not found." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel category)
        {
           var result =  await _categoryservice.AddCategory(category);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to add category." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditCategory(CategoryModel category)
        {
            var result = await _categoryservice.UpdateCategory(category);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to edit category." });
            }
        }

        [HttpDelete("{tableid}")]
        public async Task<IActionResult> deleteCategory(Guid categoryID)
        {
            var result = await _categoryservice.DeleteCategoy(categoryID);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to delete category." });
            }
        }
    }
}
