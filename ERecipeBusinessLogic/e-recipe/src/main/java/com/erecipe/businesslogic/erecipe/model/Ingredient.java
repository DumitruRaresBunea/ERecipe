package com.erecipe.businesslogic.erecipe.model;

public class Ingredient {
	public int Id;
	public String Name;
	public double Quantity;
	
	public Ingredient(int Id, String Name, double Quantity)
	{
		this.Id = Id;
		this.Name = Name;
		this.Quantity = Quantity;
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
	public double getQuantity()
	{
		return Quantity;
	}
	public void setQuantity(double Quantity)
	{
		this.Quantity = Quantity;
	}
}
