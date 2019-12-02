package com.erecipe.businesslogic.erecipe.Persistance;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.CacheResponse;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.http.HttpClient;
import java.util.List;

import com.erecipe.businesslogic.erecipe.model.*;
public class PersistanceLink {
	private static String baseRoute = "http://localhost:49951/api/";

	public PersistanceLink() 
	{
		
	}

// ---- GET
	public static String GetAuthors() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(baseRoute+"authors");
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetAuthor(int authorId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"authors/%s", authorId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipeByAuthor(int authorId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"authors/%s/recipes", authorId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	// authors/recipes/recipeId
	public static String GetAuthorsOfARecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"authors/recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetCategories() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"categories"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetCategory(int categoryId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"categories/%s", categoryId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetCategoriesOfRecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"categories/recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipesOfACategory(int categoryId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"categories/%s/recipes", categoryId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetCountries() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"countries"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetCountry(int countryId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"countries/%s", countryId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetCountryOfRecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"countries/recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipesFromCountry(int countryId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"countries/%s/recipes", countryId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetIngredients() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"ingredients"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetIngredient(int ingredientId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"ingredients/%s", ingredientId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetIngredientssOfRecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"ingredients/recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipeFromIngredient(int ingredientId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"ingredients/%s/recipes", ingredientId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipes() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"recipes"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipeRatingAverage(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"recipes/%s/rating", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReviewers() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviewers"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReviewer(int reviewerId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviewers/%s", reviewerId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReviewsByReviewer(int reviewerId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviewers/%s/reviews", reviewerId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReviewerOfAReview(int reviewId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviewers/%s/reviewer", reviewId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReviews() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviews"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReview(int reviewId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviews/%s", reviewId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetReviewsForARecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviews/recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipeOfAReview(int reviewId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"reviews/%s/recipe", reviewId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	
	public static String GetSteps() throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"steps"));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}

	public static String GetStep(int stepId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"steps/%s", stepId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetStepsOFRecipe(int recipeId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"steps/recipes/%s", recipeId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	
	public static String GetRecipeFromStep(int stepId) throws IOException
	{

	    String readLine = null;
		URL urlForGetRequest = new URL(String.format(baseRoute+"steps/%s/recipes", stepId));
		HttpURLConnection conection = (HttpURLConnection) urlForGetRequest.openConnection();
	    conection.setRequestMethod("GET");
	    
	    int responseCode = conection.getResponseCode();
	    if (responseCode == HttpURLConnection.HTTP_OK) {
	        BufferedReader in = new BufferedReader(
	            new InputStreamReader(conection.getInputStream()));
	        StringBuffer response = new StringBuffer();
	        while ((readLine = in .readLine()) != null) 
	        {
	            response.append(readLine);
	        } in .close();
	        System.out.println(response.toString());
	    } 
		
		return readLine;
	}
	

	
}
