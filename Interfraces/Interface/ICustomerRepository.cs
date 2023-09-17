using Food.DAL.ExtentedModel;
using Food.DAL.Models;
using System.Collections.Generic;

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
