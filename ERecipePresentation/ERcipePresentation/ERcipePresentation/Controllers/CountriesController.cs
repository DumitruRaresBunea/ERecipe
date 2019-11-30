using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class CountriesController : Controller
    {
        ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            var countries = _countryRepository.GetCountries();
            //var countries = new List<CountryDto>();
            if (countries.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving countries from " +
                    "the database or no country exists";
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(countries);
        }

        public IActionResult GetCountryById(int countryId)
        {
            var country = _countryRepository.GetCountry(countryId);
            //country = null;
            if (country == null)
            {
                ModelState.AddModelError("", "Error getting a country");
                ViewBag.Message = $"There was a problem retrieving country with id {countryId} " +
                    $"from the database or no country with that id exists";
                country = new CountryDTO();
            }
            return View(country);
        }

       
    }
}