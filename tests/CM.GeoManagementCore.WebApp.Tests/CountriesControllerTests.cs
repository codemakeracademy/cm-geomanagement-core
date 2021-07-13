using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.GeoManagementCore.BusinessEntities;
using CM.GeoManagementCore.Repositories;
using CM.GeoManagementCore.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CM.GeoManagementCore.WebApp.Tests
{
    public class CountriesControllerTests
    {

        [Fact]
        public void ShouldGetAllCountries()
        {
            var expected = new List<Country>()
            {
                new Country(),
                new Country(),
            };

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock
                .Setup(x => x.GetAll())
                .Returns(expected);

            var controller = new CountriesController(countryRepositoryMock.Object);
            var countryResult = controller.Get();

            Assert.IsType<OkObjectResult>(countryResult);
            var actualList = ((OkObjectResult) (countryResult)).Value as List<Country>;

            Assert.Equal(actualList, expected);
        }

        [Fact]
        public void ShouldGetSingleCountries()
        {
            var expected = new List<Country>()
            {
                new Country(),
                new Country(),
            };

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock
                .Setup(x => x.Read("US"))
                .Returns(() => null);

            var repo = countryRepositoryMock.Object;
            var country1 = repo.Read("US");
            var country2 = repo.Read("US");

            Assert.Null(country1);
            Assert.Null(country2);
        }
        
        [Fact]
        public void ShouldCallUpdateRepository()
        {
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var controller = new CountriesController(countryRepositoryMock.Object);

            var country = new Country();
            
            var result = controller.Put("US", country);

            Assert.IsType<NoContentResult>(result);

            countryRepositoryMock.Verify(x => x.Update(country));
        }

        [Fact]
        public void ShouldCloneCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "United States";

            country.Regions = new List<Region>()
            {
                new Region()
            };

            var clonedCountry = country.Clone();

            Assert.NotEqual(country, clonedCountry);

            Assert.Equal( country.CountryCode,  clonedCountry.CountryCode);
            Assert.Equal( country.CountryName,  clonedCountry.CountryName);

            Assert.NotEqual(country.Regions, clonedCountry.Regions);

        }
    }
}
