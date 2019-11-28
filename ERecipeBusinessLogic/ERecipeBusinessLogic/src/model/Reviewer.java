package model;

public class Reviewer {
	public int Id;
	public String FirstName;
	public String LastName;
	
	public Reviewer(int Id, String FirstName, String LastName)
	{
		this.Id = Id;
		this.FirstName = FirstName;
		this.LastName = LastName;
	}
	
	public int getId()
	{
		return Id;
	}
	public void setId(int Id)
	{
		this.Id = Id;
	}
	public String getFirstName()
	{
		return FirstName;
	}
	public void setFirstName(String FirstName)
	{
		this.FirstName = FirstName;
	}
	public String getLastName()
	{
		return LastName;
	}
	public void setLastName(String LastName)
	{
		this.LastName = LastName;
	}
}
