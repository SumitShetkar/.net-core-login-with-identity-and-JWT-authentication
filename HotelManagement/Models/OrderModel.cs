using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderDetailsId { get; set; }
        public Guid TableId { get; set; }
        public OrderDetailsModel OrderDetails { get; set; }
        public TablesModel Table { get; set; }
    }
}
