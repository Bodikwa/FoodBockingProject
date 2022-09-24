using System;
using System.Collections.Generic;

#nullable disable

namespace Food.DAL.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int FoodTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual FoodType FoodType { get; set; }
    }
}
