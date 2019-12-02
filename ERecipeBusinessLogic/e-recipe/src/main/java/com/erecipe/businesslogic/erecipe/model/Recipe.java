package com.erecipe.businesslogic.erecipe.model;

import java.time.LocalDateTime;

public class Recipe 
{
	public int Id;
	public String Name;
	public String Description;
	public LocalDateTime PublishDate;
	
	public Recipe(int Id, String Name, String Description, LocalDateTime PublishDate)
	{
		this.Id = Id;
		this.Name = Name;
		this.Description = Description;
		this.PublishDate = PublishDate;
	}
	
	public int getId()
	{
		return Id;
	}
	public void setId(int Id)
	{
		this.Id = Id;
	}
	public String getName()
	{
		return Name;
	}
	public void setName(String Name)
	{
		this.Name = Name;
	}
	public String getDescription()
	{
		return Description;
	}
	public void setDescription(String Description)
	{
		this.Description = Description;
	}
	public LocalDateTime getPublishDate()
	{
		return PublishDate;
	}
	public void setPublishDate(LocalDateTime PublishDate)
	{
		this.PublishDate = PublishDate;
	}
}
