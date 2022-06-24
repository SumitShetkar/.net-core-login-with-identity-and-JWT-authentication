using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
   public  interface IItemService
    {
        Task<IEnumerable<ItemsModel>> GetAllItems();

        Task<int> AddItem(ItemsModel item);

        Task<int> UpdateItem(ItemsModel item);

        Task<int> DeleteItem(Guid itemId);

        Task<ItemsModel> GetItemById(Guid itemId);
    }
}
