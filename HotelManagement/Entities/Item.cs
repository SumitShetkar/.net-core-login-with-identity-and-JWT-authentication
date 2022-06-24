using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey("Type")]
        public Guid TypeId { get; set; }
        public double Price { get; set; }
        public DateTime AddedOn { get; set; }
        [ForeignKey("AppUser")]
        public string AddedBy { get; set; }
        //navigation properties
        public Category Category { get; set; }
        public Type Type { get; set; }
    }

}
