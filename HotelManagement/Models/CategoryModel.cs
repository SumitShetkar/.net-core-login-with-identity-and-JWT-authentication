using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
