using System;

namespace Food.DAL.ExtentedModel
{
   public class CustomerFoodTypeOrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string OrderName { get; set; }

    }
}
