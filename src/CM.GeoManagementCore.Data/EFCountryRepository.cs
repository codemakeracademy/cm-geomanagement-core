using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagementCore.BusinessEntities;
using CM.GeoManagementCore.Repositories;

namespace CM.GeoManagementCore.Data
{
    public class EFCountryRepository : ICountryRepository
    {
        public void Create(Country country)
        {
            throw new NotImplementedException();
        }

        public Country Read(string countryCode)
        {
            throw new NotImplementedException();
        }

        public void Update(Country country)
        {
            throw new NotImplementedException();
        }

        public void Delete(string countryCode)
        {
           // get country
           throw new NotFoundException($"Country with code {countryCode} does not exist");
           
           // delete country
        }

        public List<Country> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
