package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;
import com.erecipe.businesslogic.erecipe.DaoServices.CountryDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class CountryController {
	@Autowired
	private CountryDaoService service;
	@GetMapping("/countries")
	public String GetCountries() throws IOException
	{
		return service.GetCountries();
	}
	@GetMapping("/countries/{id}")
	public String GetCountry(@PathVariable int countryId) throws IOException
	{
		return service.GetCountry(countryId);
	}
	@GetMapping("/countries/recipes/{id}")
	public String GetCountryOfRecipe(@PathVariable int recipeId) throws IOException
	{
		return service.GetCountryOfRecipe(recipeId);
	}
	@GetMapping("/countries/{id}/recipes")
	public String GetRecipesFromCountry(@PathVariable int countryId) throws IOException
	{
		return service.GetRecipesFromCountry(countryId);
	}
}
