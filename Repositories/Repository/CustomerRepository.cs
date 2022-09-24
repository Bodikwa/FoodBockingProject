using Food.DAL.ExtentedModel;
using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Repositories.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly FoodDBContext _context;

        public CustomerRepository(FoodDBContext context)
        {
            _context = context;
        }

        public void DeleteCustomer(int CustomerId)
        {
            Customer customer = _context.Customers.Find(CustomerId);
            _context.Customers.Remove(customer);
        }

        public IEnumerable<CountryCustomerModel> GetAllCustomers()
        {

            var results = _context.Customers.Include(x => x.Country).ToList();

            List<CountryCustomerModel> CustomerData = new List<CountryCustomerModel>();

            foreach (var r in results)
            {
                CustomerData.Add(new CountryCustomerModel()
                {
                 
             CustomerId =r.CustomerId,
             Name=r.Name,
             Surname =r.Surname,
              ContactNumber =r.ContactNumber,
            EnailAdress =r.EnailAdress,
            CountryName = r.Country.CountryName,

                 });
            }
            return CustomerData;
        }

        public Customer GetCustomerById(int CustomerId)
        {
            return _context.Customers.Find(CustomerId);
        }

        public void InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void SaveCustomer()
        {
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
