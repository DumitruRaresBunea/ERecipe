package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@Component
public class ReviewersDaoService {

	public String GetReviewers() throws IOException
	{
		return PersistanceLink.GetReviewers();
	}
	
	public String GetReviewer(int reviewerId) throws IOException
	{
		return PersistanceLink.GetReviewer(reviewerId);
	}
	
	public String GetReviewsByReviewer(int reviewerId) throws IOException
	{
		return PersistanceLink.GetReviewsByReviewer(reviewerId);
	}
	
	public String GetReviewerOfAReview(int reviewId) throws IOException
	{
		return PersistanceLink.GetReviewerOfAReview(reviewId);
	}
	
}
