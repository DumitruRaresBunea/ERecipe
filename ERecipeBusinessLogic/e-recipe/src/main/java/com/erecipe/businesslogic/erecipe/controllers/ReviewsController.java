package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.erecipe.businesslogic.erecipe.DaoServices.ReviewsDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;

@RestController
public class ReviewsController {
	@Autowired
	private ReviewsDaoService service;
	@GetMapping("/reviews")
	public String GetReviews() throws IOException
	{
		return PersistanceLink.GetReviews();
	}
	@GetMapping("/reviews/{id}")
	public String GetReview(@PathVariable int reviewId) throws IOException
	{
		return PersistanceLink.GetReview(reviewId);
	}
	@GetMapping("/reviews/recipes/{id}")
	public String GetReviewsForARecipe(@PathVariable int recipeId) throws IOException
	{
		return PersistanceLink.GetReviewsForARecipe(recipeId);
	}
	@GetMapping("/reviews/{id}/recipe")
	public String GetRecipeOfAReview(@PathVariable int reviewId) throws IOException
	{
		return PersistanceLink.GetRecipeOfAReview(reviewId);
	}
}
