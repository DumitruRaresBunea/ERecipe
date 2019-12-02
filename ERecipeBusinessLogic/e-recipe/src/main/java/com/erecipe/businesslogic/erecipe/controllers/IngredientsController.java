package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.erecipe.businesslogic.erecipe.DaoServices.IngredientsDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class IngredientsController {
	@Autowired
	private IngredientsDaoService service;
	@GetMapping("/ingredients")
	public String GetIngredients() throws IOException
	{
		return service.GetIngredients();
	}
	@GetMapping("/ingredients/{id}")
	public String GetIngredient(@PathVariable int ingredientId) throws IOException
	{
		return service.GetIngredient(ingredientId);
	}
	@GetMapping("/ingredients/recipes/{id}")
	public String GetIngredientssOfRecipe(@PathVariable int recipeId) throws IOException
	{
		return service.GetIngredientssOfRecipe(recipeId);
	}
	@GetMapping("/ingredients/{id}/recipes")
	public String GetRecipeFromIngredient(@PathVariable int ingredientId) throws IOException
	{
		return service.GetRecipeFromIngredient(ingredientId);
	}
}
