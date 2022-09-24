using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.DAL.ExtentedModel
{
   public class CustomerFoodTypeOrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int OrderName { get; set; }

    }
}
