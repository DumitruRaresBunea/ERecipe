package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;
import com.erecipe.businesslogic.erecipe.DaoServices.AuthorDaoSerivce;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class AuthorController {

	@Autowired
	private AuthorDaoSerivce service;
	@GetMapping("/authors")
	public String GetAuthors() throws IOException
	{
		return service.GetAuthors();
	}
	@GetMapping("/authors/{id}")
	public String GetAuthor(@PathVariable int authorId) throws IOException
	{
		return service.GetAuthor(authorId);
	}
	
	@GetMapping("/authors/{id}/recipes")
	public String GetRecipeByAuthor(@PathVariable int authorId) throws IOException
	{
		return service.GetRecipeByAuthor(authorId);
	}
	@GetMapping("/authors/recipes/{id}")
	public String service(@PathVariable int recipeId) throws IOException
	{
		return PersistanceLink.GetAuthorsOfARecipe(recipeId);
	}
	
}
