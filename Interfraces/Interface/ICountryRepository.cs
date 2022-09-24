
using Food.DAL.Models;
using System.Collections.Generic;


namespace Interfraces.Interface
{
  public  interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int CountryId);
        void InsertCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int CountryId);
        void SaveCountry();

    }
}
