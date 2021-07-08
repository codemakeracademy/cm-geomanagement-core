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
    [ApiController]
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
            return Ok(_countryRepository.GetAll());
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
        public ActionResult Post([FromBody] string value)
        {
            throw new Exception("Server Error");
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            throw new NotFoundException($"Country with id {id} was not found");
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _countryRepository.Delete(id);
        }
    }
}
