using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.GeoManagementCore.Repositories;
using CM.GeoManagementCore.WebApp.Controllers;
using Moq;
using Xunit;

namespace CM.GeoManagementCore.WebApp.Tests
{
    public class CountriesControllerTests
    {

        [Fact]
        public void ShouldGetAllCountries()
        {
            var countryRepositoryMock = new Mock<ICountryRepository>();

         //   var controller = new CountriesController(countryRepositoryMock.Object);
         //   var countries = controller.Get();

            //Assert.NotNull();
        }
    }
}
