using System;
using System.Collections.Generic;

#nullable disable

namespace Food.DAL.Models
{
    public partial class FoodType
    {
        public FoodType()
        {
            Orders = new HashSet<Order>();
        }

        public int FoodTypeId { get; set; }
        public string FoodName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
