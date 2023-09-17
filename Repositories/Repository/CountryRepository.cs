using Food.DAL.Models;
using Interfraces.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repository
{
    public class CountryRepository : ICountryRepository
    {


        private readonly FoodDBContext _context;

        public CountryRepository(FoodDBContext context)
        {
            _context = context;
        }



        public void DeleteCountry(int CountryId)
        {
            Country country = _context.Countries.Find(CountryId);
            _context.Countries.Remove(country);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int CountryId)
        {
            return _context.Countries.Find(CountryId);
        }

        public void InsertCountry(Country country)
        {
            _context.Countries.Add(country);
        }

        public void SaveCountry()
        {
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
        }
    }
}
