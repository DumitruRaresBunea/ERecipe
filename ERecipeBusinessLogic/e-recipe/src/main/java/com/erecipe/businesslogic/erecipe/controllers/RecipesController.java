package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.erecipe.businesslogic.erecipe.DaoServices.RecipesDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class RecipesController {
	@Autowired
	private RecipesDaoService service;
	@GetMapping("/recipes")
	public String GetRecipes() throws IOException
	{
		return service.GetRecipes();
	}
	@GetMapping("/recipes/{id}")
	public String GetRecipe(@PathVariable int recipeId) throws IOException
	{
		return service.GetRecipe(recipeId);
	}
	@GetMapping("/recipes/{id}/rating")
	public String GetRecipeRatingAverage(@PathVariable int recipeId) throws IOException
	{
		return service.GetRecipeRatingAverage(recipeId);
	}
	
}
