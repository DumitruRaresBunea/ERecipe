package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@Component
public class RecipesDaoService {
	
	public String GetRecipes() throws IOException
	{
		return PersistanceLink.GetRecipes();
	}
	
	public String GetRecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetRecipe(recipeId);
	}
	
	public String GetRecipeRatingAverage(int recipeId) throws IOException
	{
		return PersistanceLink.GetRecipeRatingAverage(recipeId);
	}
}
