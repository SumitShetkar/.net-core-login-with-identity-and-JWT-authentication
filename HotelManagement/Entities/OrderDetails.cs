using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class OrderDetails
    {
        public Guid Id { get; set; }

   
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        public double Quanitity { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public string Status { get; set; }
        public string StatusUpdatedBy { get; set; }
    
        //navigation properties
   
        public Item Items { get; set; }

        [ForeignKey("AddedBy")]
        public virtual AppUser AddedUser { get; set; }

        [ForeignKey("StatusUpdatedBy")]
        public virtual AppUser StatusUpdatedUser { get; set; }
    }
}
