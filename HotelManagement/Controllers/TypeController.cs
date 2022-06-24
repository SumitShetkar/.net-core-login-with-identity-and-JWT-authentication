using HotelManagement.Entities;
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
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
           
           var result = await _typeService.GetAllTypes();
           if(result != null)
            {
                return Ok(result);
            }
           else
            {
                return Ok(new {success = true, data = "Empty data" });
            }
        
        }

        [HttpPost]
        public async Task<IActionResult> AddType(TypeModel type)
        {
           var res =  await _typeService.AddType(type);
            if (res == 1)
            {
                return Ok(res);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to add type." });
            }
        }

        [HttpDelete]
        [Route("{TId}")]
        public async Task<IActionResult> DeleteType(Guid TId)
        {
            var res = await _typeService.DeleteType(TId);
            if (res == 1)
            {
                return Ok(res);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to delete Type." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateType(TypeModel type)
        {
            var res = await _typeService.UpdateType(type);
            if (res == 1)
            {
                return Ok(res);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to Update Type." });
            }
        }
    }
}
