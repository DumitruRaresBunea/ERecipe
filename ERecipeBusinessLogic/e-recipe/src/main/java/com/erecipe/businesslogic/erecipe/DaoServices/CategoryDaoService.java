package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@Component
public class CategoryDaoService {
	
	public String GetCategories() throws IOException
	{
		return PersistanceLink.GetCategories();
	}
	
	public String GetCategory(int categoryId) throws IOException
	{
		return PersistanceLink.GetCategory(categoryId);
	}
	
	public String GetCategoriesOfRecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetCategoriesOfRecipe(recipeId);
	}
	
	public String GetRecipesOfACategory(int categoryId) throws IOException
	{
		return PersistanceLink.GetRecipesOfACategory(categoryId);
	}

}
