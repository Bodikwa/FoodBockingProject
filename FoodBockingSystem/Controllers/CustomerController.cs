using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FoodBockingSystem.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly ICountryRepository _countryRepository;


        public CustomerController(ICustomerRepository customerRepository, ICountryRepository countryRepository)
        {
            _customerRepository = customerRepository;
            _countryRepository = countryRepository;

        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerRepository.GetAllCustomers());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            CountryViewbag();
            return View(_customerRepository.GetCustomerById(id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            CountryViewbag();
            return View();
        }


        private void CountryViewbag()
        {
            var countryModels = _countryRepository.GetAllCountries();

            List<SelectListItem> countryModelsOption = new List<SelectListItem>();

            foreach (var c in countryModels)
            {
                countryModelsOption.Add(new SelectListItem(c.CountryName, c.CountryId.ToString()));
            }
            ViewBag.countryViewbag = countryModelsOption;
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Customer customer)
        {
            try
            {
                _customerRepository.InsertCustomer(customer);
                _customerRepository.SaveCustomer();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CountryViewbag();
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            CountryViewbag();
            return View(_customerRepository.GetCustomerById(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);
                _customerRepository.SaveCustomer();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CountryViewbag();
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            CountryViewbag();
            return View(_customerRepository.GetCustomerById(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Customer customer)
        {
            try
            {
                _customerRepository.DeleteCustomer(customer.CustomerId);
                _customerRepository.SaveCustomer();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CountryViewbag();
                return View();
            }
        }
    }
}
