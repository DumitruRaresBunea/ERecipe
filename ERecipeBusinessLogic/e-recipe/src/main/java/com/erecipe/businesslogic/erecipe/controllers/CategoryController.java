package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.erecipe.businesslogic.erecipe.DaoServices.CategoryDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class CategoryController {
	
	@Autowired
	private CategoryDaoService service;
	
	@GetMapping("/categories")
	public String GetCategories() throws IOException
	{
		return service.GetCategories();
	}
	@GetMapping("/categories/{id}")
	public String GetCategory(@PathVariable int categoryId) throws IOException
	{
		return service.GetCategory(categoryId);
	}
	@GetMapping("/categories/recipes/{id}")
	public String GetCategoriesOfRecipe(@PathVariable int recipeId) throws IOException
	{
		return service.GetCategoriesOfRecipe(recipeId);
	}
	@GetMapping("/categories/{id}/recipes")
	public String GetRecipesOfACategory(@PathVariable int categoryId) throws IOException
	{
		return service.GetRecipesOfACategory(categoryId);
	}

}
