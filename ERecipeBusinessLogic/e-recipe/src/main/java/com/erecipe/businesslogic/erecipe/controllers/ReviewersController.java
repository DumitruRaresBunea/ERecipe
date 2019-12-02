package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.erecipe.businesslogic.erecipe.DaoServices.ReviewersDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class ReviewersController {
	@Autowired
	private ReviewersDaoService service;
	@GetMapping("/reviewers")
	public String GetReviewers() throws IOException
	{
		return service.GetReviewers();
	}
	@GetMapping("/reviewers/{id}")
	public String GetReviewer(@PathVariable int reviewerId) throws IOException
	{
		return service.GetReviewer(reviewerId);
	}
	@GetMapping("/reviewers/{id}/reviews")
	public String GetReviewsByReviewer(@PathVariable int reviewerId) throws IOException
	{
		return service.GetReviewsByReviewer(reviewerId);
	}
	@GetMapping("/reviewers/{id}/reviewer")
	public String GetReviewerOfAReview(@PathVariable int reviewId) throws IOException
	{
		return service.GetReviewerOfAReview(reviewId);
	}
	
}
