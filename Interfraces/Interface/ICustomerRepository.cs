using Food.DAL.ExtentedModel;
using Food.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfraces.Interface
{
   public interface ICustomerRepository
    {
        IEnumerable<CountryCustomerModel> GetAllCustomers();
        Customer GetCustomerById(int CustomerId);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int CustomerId);
        void SaveCustomer();
    }
}
