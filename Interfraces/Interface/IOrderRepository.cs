using Food.DAL.ExtentedModel;
using Food.DAL.Models;
using System.Collections.Generic;


namespace Interfraces.Interface
{
   public interface IOrderRepository
    {
        IEnumerable<CustomerFoodTypeOrderModel> GetAllOrders();
        Order GetOrderById(int OrderId);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int OrderId);
        void SaveOrder();

    }
}
