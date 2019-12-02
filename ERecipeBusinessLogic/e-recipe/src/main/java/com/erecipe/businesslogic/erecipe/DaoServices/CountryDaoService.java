package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@Component
public class CountryDaoService {
	
	public String GetCountries() throws IOException
	{
		return PersistanceLink.GetCountries();
	}
	
	public String GetCountry(int countryId) throws IOException
	{
		return PersistanceLink.GetCountry(countryId);
	}
	
	public String GetCountryOfRecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetCountryOfRecipe(recipeId);
	}
	
	public String GetRecipesFromCountry(int countryId) throws IOException
	{
		return PersistanceLink.GetRecipesFromCountry(countryId);
	}
	
}
