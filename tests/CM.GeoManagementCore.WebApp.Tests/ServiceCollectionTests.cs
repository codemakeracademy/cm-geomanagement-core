using System;
using CM.GeoManagementCore.Data;
using CM.GeoManagementCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CM.GeoManagementCore.WebApp.Tests
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void ShouldRegisterServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ICountryRepository, EFCountryRepository>();
            serviceCollection.AddTransient<TestDI>();

            var provider = serviceCollection.BuildServiceProvider();

            var countryRepository
                = provider.GetService<ICountryRepository>();

            var countryRepository2
                = provider.GetService<ICountryRepository>();

            Assert.Same(countryRepository, countryRepository2);

            Assert.IsAssignableFrom<EFCountryRepository>(countryRepository);

            var testDI = provider.GetService<TestDI>();

            Assert.IsAssignableFrom<EFCountryRepository>(testDI.CountryRepository);
            Assert.Same(testDI.CountryRepository, countryRepository);

        }

        public class TestDI
        {
            public ICountryRepository CountryRepository { get; }

            public TestDI(ICountryRepository countryRepository)
            {
                CountryRepository = countryRepository;
            }
        }
    }
}
