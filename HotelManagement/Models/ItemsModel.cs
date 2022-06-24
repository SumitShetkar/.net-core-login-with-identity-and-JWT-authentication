using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class ItemsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TypeId { get; set; }
        public double Price { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public CategoryModel Category { get; set; }
        public TypeModel Type { get; set; }
    }
}
