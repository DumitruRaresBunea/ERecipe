package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@Component
public class ReviewsDaoService {

	public String GetReviews() throws IOException
	{
		return PersistanceLink.GetReviews();
	}
	
	public String GetReview(int reviewId) throws IOException
	{
		return PersistanceLink.GetReview(reviewId);
	}
	
	public String GetReviewsForARecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetReviewsForARecipe(recipeId);
	}
	
	public String GetRecipeOfAReview(int reviewId) throws IOException
	{
		return PersistanceLink.GetRecipeOfAReview(reviewId);
	}
	
}
