using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        //api/countries
        [HttpGet]        
        public IActionResult GetCountires()
        {
            var countries = _countryRepository.GetCountries().ToList();
            return Ok(countries);
        }
    }
}