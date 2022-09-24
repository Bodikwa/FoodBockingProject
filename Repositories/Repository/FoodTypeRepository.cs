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
   public class FoodTypeRepository : IFoodTypeRepository
    {

        private readonly FoodDBContext _context;

        public FoodTypeRepository(FoodDBContext context)
        {
            _context = context;
        }
        public void DeleteFoodType(int FoodTypeId)
        {
            FoodType foodType = _context.FoodTypes.Find(FoodTypeId);
            _context.FoodTypes.Remove(foodType);
        }

        public IEnumerable<FoodType> GetAllFoodTypes()
        {
            return _context.FoodTypes.ToList();
        }

        public FoodType GetFoodTypeById(int FoodTypeId)
        {
            return _context.FoodTypes.Find(FoodTypeId);
        }

        public void InsertFoodType(FoodType foodType)
        {
            _context.FoodTypes.Add(foodType);
        }

        public void SaveFoodType()
        {
            _context.SaveChanges();
        }

        public void UpdateFoodType(FoodType foodType)
        {
            _context.Entry(foodType).State = EntityState.Modified;
        }
    }
}
