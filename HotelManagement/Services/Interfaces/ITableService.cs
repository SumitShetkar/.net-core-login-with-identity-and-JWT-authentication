using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TablesModel>> GetAllTables();

        Task<int> AddTable(TablesModel table );

        Task<int> UpdateTable(TablesModel table);

        Task<int> DeleteTable(Guid tableId);

        Task<TablesModel> GetTableById(Guid tableId);


    }
}
