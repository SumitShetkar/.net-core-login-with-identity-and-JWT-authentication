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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemservice;
        public ItemController(IItemService itemservice)
        {
            _itemservice = itemservice;
        }

        [HttpGet]
        public async Task<ActionResult<ItemsModel>> GetAllItems()
        {
            var result = await _itemservice.GetAllItems();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Items not found." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemsModel item)
        {
            item.Category = null;
            item.Type = null;
            var result = await _itemservice.AddItem(item);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to add item." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditItem(ItemsModel item)
        {
            var result = await _itemservice.UpdateItem(item);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to edit item." });
            }
        }

        [HttpDelete("{itemid}")]
        public async Task<IActionResult> deleteItem(Guid itemid)
        {
            var result = await _itemservice.DeleteItem(itemid);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to delete item." });
            }
        }
    }
}
