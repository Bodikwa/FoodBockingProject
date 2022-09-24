using Food.DAL.ExtentedModel;
using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly FoodDBContext _context;
        public OrderRepository(FoodDBContext context)
        {
            _context = context;
        }


        public void DeleteOrder(int OrderId)
        {
            Order order = _context.Orders.Find(OrderId);
            _context.Orders.Remove(order);
        }

        public IEnumerable<CustomerFoodTypeOrderModel> GetAllOrders()
        {
            var results = _context.Orders.Include(x => x.Customer).ToList();

            List<CustomerFoodTypeOrderModel> CustomerData = new List<CustomerFoodTypeOrderModel>();

            foreach (var r in results)
            {
                CustomerData.Add(new CustomerFoodTypeOrderModel()
                {

                    //CustomerId = r.CustomerId,
                    //Name = r.Name,
                    //Surname = r.Surname,
                    //ContactNumber = r.ContactNumber,
                    //EnailAdress = r.EnailAdress,
                    //CountryName = r.Country.CountryName,

                         OrderId =r.OrderId,
                         OrderDate =r.OrderDate,
                       CustomerName =r.Customer.Name,
                      // OrderName =r.FoodType.FoodName,

    });
            }
            return CustomerData;
        }

        public Order GetOrderById(int OrderId)
        {
            return _context.Orders.Find(OrderId);
        }

        public void InsertOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void SaveOrder()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
