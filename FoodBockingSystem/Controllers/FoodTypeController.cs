using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBockingSystem.Controllers
{
    public class FoodTypeController : Controller
    {
        private readonly IFoodTypeRepository _foodTypeRepository;



        public FoodTypeController(IFoodTypeRepository foodTypeRepository)
        {
            _foodTypeRepository = foodTypeRepository;

        }


        // GET: FoodTypeController
        public ActionResult Index()
        {
            return View(_foodTypeRepository.GetAllFoodTypes());
        }

        // GET: FoodTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_foodTypeRepository.GetFoodTypeById(id));
        }

        // GET: FoodTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] FoodType foodType )
        {
            try
            {
                _foodTypeRepository.InsertFoodType(foodType);
                _foodTypeRepository.SaveFoodType();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_foodTypeRepository.GetFoodTypeById(id));
        }

        // POST: FoodTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] FoodType foodType)
        {
            try
            {
                _foodTypeRepository.UpdateFoodType(foodType);
                _foodTypeRepository.SaveFoodType();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_foodTypeRepository.GetFoodTypeById(id));
        }

        // POST: FoodTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] FoodType foodType)
        {
            try
            {
                _foodTypeRepository.DeleteFoodType(foodType.FoodTypeId);
                _foodTypeRepository.SaveFoodType();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
