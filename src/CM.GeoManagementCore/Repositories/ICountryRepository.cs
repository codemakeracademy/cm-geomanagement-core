using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagementCore.BusinessEntities;

namespace CM.GeoManagementCore.Repositories
{
    public interface ICountryRepository
    {
        void Create(Country country);
        Country Read(string countryCode);
        void Update(Country country);
        void Delete(string countryCode);

        List<Country> GetAll();
    }
}
