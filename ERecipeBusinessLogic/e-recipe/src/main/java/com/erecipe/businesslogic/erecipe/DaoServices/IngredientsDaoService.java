package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
import org.springframework.stereotype.Component;
@Component
public class IngredientsDaoService {
	
	public String GetIngredients() throws IOException
	{
		return PersistanceLink.GetIngredients();
	}
	
	public String GetIngredient(int ingredientId) throws IOException
	{
		return PersistanceLink.GetIngredient(ingredientId);
	}
	
	public String GetIngredientssOfRecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetIngredientssOfRecipe(recipeId);
	}
	
	public String GetRecipeFromIngredient(int ingredientId) throws IOException
	{
		return PersistanceLink.GetRecipeFromIngredient(ingredientId);
	}
}
