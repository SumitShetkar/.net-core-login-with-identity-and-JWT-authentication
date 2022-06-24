using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services.Interfaces
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeModel>> GetAllTypes();

        Task<int> AddType(TypeModel type);

        Task<int> UpdateType(TypeModel type);

        Task<int> DeleteType(Guid typeId);
    }
}
