using Food.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfraces.Interface
{
   public interface IFoodTypeRepository
    {
        IEnumerable<FoodType> GetAllFoodTypes();
        FoodType GetFoodTypeById(int FoodTypeId);
        void InsertFoodType(FoodType foodType);
        void UpdateFoodType(FoodType foodType);
        void DeleteFoodType(int FoodTypeId);
        void SaveFoodType();
    }
}

