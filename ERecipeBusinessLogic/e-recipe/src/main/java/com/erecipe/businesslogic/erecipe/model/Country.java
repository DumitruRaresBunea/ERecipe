package com.erecipe.businesslogic.erecipe.model;

public class Country 
{
	public int Id;
	public String Name;
	
	public Country(int Id, String Name)
	{
		this.Id = Id;
		this.Name = Name;
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
}
