
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class OrderDetailsModel
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }
        public double Quanitity { get; set; }

        public DateTime AddedOn { get; set; }

        public string AddedBy { get; set; }
        public string Status { get; set; }
        public string StatusUpdatedBy { get; set; }

        //navigation properties
    
        public ItemsModel Item { get; set; }
        public virtual AppUser AddedUser { get; set; }
        public virtual AppUser StatusUpdatedUser { get; set; }


    }
}
