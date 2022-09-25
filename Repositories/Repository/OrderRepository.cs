using Food.DAL.ExtentedModel;
using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


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
            
            var results = _context.Orders.Include(x => x.Customer).Include(p=>p.FoodType).ToList();

            List<CustomerFoodTypeOrderModel> CustomerData = new List<CustomerFoodTypeOrderModel>();

            foreach (var r in results)
            {
                CustomerData.Add(new CustomerFoodTypeOrderModel()
                {
                         OrderId =r.OrderId,
                         OrderDate =r.OrderDate,
                        CollectionDate=r.CollectionDate,
                       CustomerName =r.Customer.Name,
                       OrderName =r.FoodType.FoodName,
                       

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
