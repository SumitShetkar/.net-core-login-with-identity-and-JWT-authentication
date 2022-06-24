using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }

        [ForeignKey("OrderDetails")]
        public Guid OrderDetailsId { get; set; }

        [ForeignKey("Table")]
        public Guid TableId { get; set; }

        //navigation properties
        public OrderDetails OrderDetails { get; set; }
        public Table Table { get; set; }
    }
}
