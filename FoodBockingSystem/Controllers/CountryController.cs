using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace FoodBockingSystem.Controllers
{
    public class CountryController : Controller
    {
        // GET: CountryController


        private readonly ICountryRepository _countryRepository;
 


        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        
        }

        public ActionResult Index()
        {
            return View(_countryRepository.GetAllCountries().ToList());
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View(_countryRepository.GetCountryById(id));
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Country country)
        {
            try
            {

                _countryRepository.InsertCountry(country);
                _countryRepository.SaveCountry();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_countryRepository.GetCountryById(id));
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Country country)
        {
            try
            {
                _countryRepository.UpdateCountry(country);
                _countryRepository.SaveCountry();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_countryRepository.GetCountryById(id));
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Country country)
        {
            try
            {
                _countryRepository.DeleteCountry(country.CountryId);
                _countryRepository.SaveCountry();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
