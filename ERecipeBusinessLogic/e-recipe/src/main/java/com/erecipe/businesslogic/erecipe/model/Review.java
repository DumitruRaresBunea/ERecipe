package com.erecipe.businesslogic.erecipe.model;

public class Review 
{
	public int Id;
	public String ReviewText;
	public String Headline;
	public int Rating;
	
	public Review(int Id, String ReviewText, String Headline, int Rating)
	{
		this.Id = Id;
		this.ReviewText = ReviewText;
		this.Headline = Headline;
		this.Rating = Rating;
	}
	
	public int getId()
	{
		return Id;
	}
	public void setId(int Id)
	{
		this.Id = Id;
	}
	public String getReviewText()
	{
		return ReviewText;
	}
	public void setReviewText(String ReviewText)
	{
		this.ReviewText = ReviewText;
	}
	public String getHeadline()
	{
		return Headline;
	}
	public void setHeadline(String Headline)
	{
		this.Headline = Headline;
	}
	public int getRating()
	{
		return Rating;
	}
	public void setRating(int Rating)
	{
		this.Rating = Rating;
	}
}
