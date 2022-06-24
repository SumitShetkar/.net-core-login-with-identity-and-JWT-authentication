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
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableservice;

        public TableController(ITableService tableservice)
        {
            _tableservice = tableservice;

        }

        [HttpGet]
        public async Task<ActionResult<TablesModel>> GetAllTables()
        {
           var result = await _tableservice.GetAllTables();
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
        public async Task<IActionResult> AddTable(TablesModel table)
        {
            
            var result = await _tableservice.AddTable(table);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to add table." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditTable(TablesModel table)
        {
            var result = await _tableservice.UpdateTable(table);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to add table." });
            }
        }

        [HttpDelete("{tableid}")]
        public async Task<IActionResult> deleteTable(Guid tableid)
        {
            var result = await _tableservice.DeleteTable(tableid);
            if (result == 1)
            {
                return Ok(result);
            }
            else
            {
                return Ok(new { status = StatusCodes.Status400BadRequest, success = false, data = "Not able to add table." });
            }
        }
    }
}
