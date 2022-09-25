using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;


namespace FoodBockingSystem.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;

        public OrderController(IOrderRepository orderRepository, 
                                 ICustomerRepository customerRepository,
                                     IFoodTypeRepository foodTypeRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _foodTypeRepository = foodTypeRepository;
        }


        // GET: OrderIdController
        public ActionResult Index()
        {
          //  if (searchBy== "CustomerName")
           // {
                return View(_orderRepository.GetAllOrders());
          //  }
          //  else
          //  {

          //  }

           // return View(_orderRepository.GetAllOrders());

        }

        // GET: OrderIdController/Details/5
        public ActionResult Details(int id)
        {
          
            return View(_orderRepository.GetOrderById(id));
        }

        // GET: OrderIdController/Create
        public ActionResult Create()
        {
            CostomerViewbag();
            FoodTypeViewbag();
            return View();
        }


        private void CostomerViewbag()
        {
            var costomerModels = _customerRepository.GetAllCustomers();

            List<SelectListItem> costomerModelsOption = new List<SelectListItem>();

            foreach (var r in costomerModels)
            {
                costomerModelsOption.Add(new SelectListItem(r.Name, r.CustomerId.ToString()));
            }
            ViewBag.costomerViewbag = costomerModelsOption;
        }

        private void FoodTypeViewbag()
        {
            var foodTypeModels = _foodTypeRepository.GetAllFoodTypes();

            List<SelectListItem> foodTypeModelsOption = new List<SelectListItem>();

            foreach (var c in foodTypeModels)
            {
                foodTypeModelsOption.Add(new SelectListItem(c.FoodName, c.FoodTypeId.ToString()));
            }
            ViewBag.foodTypeViewbag = foodTypeModelsOption;
        }

        // POST: OrderIdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Order order)
        {
            try
            {
                _orderRepository.InsertOrder(order);
                _orderRepository.SaveOrder();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CostomerViewbag();
                FoodTypeViewbag();
                return View();
            }
        }

        // GET: OrderIdController/Edit/5
        public ActionResult Edit(int id)
        {
            CostomerViewbag();
            FoodTypeViewbag();
            return View(_orderRepository.GetOrderById(id));
        }

        // POST: OrderIdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Order order)
        {
            try
            {
                _orderRepository.UpdateOrder(order);
                _orderRepository.SaveOrder();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CostomerViewbag();
                FoodTypeViewbag();
                return View();
            }
        }

        // GET: OrderIdController/Delete/5
        public ActionResult Delete(int id)
        {
            CostomerViewbag();
            FoodTypeViewbag();
            return View(_orderRepository.GetOrderById(id));
        }

        // POST: OrderIdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Order order)
        {
            try
            {
                _orderRepository.DeleteOrder(order.OrderId);
                _orderRepository.SaveOrder();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CostomerViewbag();
                FoodTypeViewbag();
                return View();
            }
        }
    }
}
