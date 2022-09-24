using Food.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfraces.Interface
{
   public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int OrderId);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int OrderId);
        void SaveOrder();

    }
}
