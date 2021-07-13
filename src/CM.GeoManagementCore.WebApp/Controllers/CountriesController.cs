using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.GeoManagementCore.BusinessEntities;
using CM.GeoManagementCore.Repositories;
using CM.GeoManagementCore.WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM.GeoManagementCore.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _countryRepository.GetAll();

            return Ok(list);
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Country), 202)]
        public ActionResult Get(int id)
        {
            throw new ValidationException("Validation");
        }
        
        // POST api/<CountriesController>
        [HttpPost]
        public IActionResult Post([FromBody] Country value)
        {
            return Ok();
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{countryCode}")]
        public ActionResult Put(string countryCode, [FromBody] Country country)
        {
            _countryRepository.Update(country);

            return NoContent();
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{countryCode}")]
        public void Delete(string countryCode)
        {
            _countryRepository.Delete(countryCode);
        }
    }
}
