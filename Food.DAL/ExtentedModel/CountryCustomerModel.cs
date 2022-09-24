using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.DAL.ExtentedModel
{
   public class CountryCustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public string EnailAdress { get; set; }
        public string CountryName { get; set; }

    }
}
