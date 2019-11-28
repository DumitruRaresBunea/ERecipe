package model;

public class Author 
{
	public int Id;
	public String Email;
	public String FirstName;
	public String LastName;
	public String PhoneNumber;
	
	public Author(int Id, String Email, String FirstName, String LastName, String PhoneNumber)
	{
		this.Id = Id;
		this.Email = Email;
		this.FirstName = FirstName;
		this.LastName = LastName;
		this.PhoneNumber = PhoneNumber;
	}
	
	public int getId()
	{
		return Id;
	}
	public void setId(int Id)
	{
		this.Id = Id;
	}
	public String getEmail()
	{
		return Email;
	}
	public void setEmail(String Email)
	{
		this.Email = Email;
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
	public String getPhoneNumber()
	{
		return PhoneNumber;
	}
	public void setPhoneNumber(String PhoneNumber)
	{
		this.PhoneNumber = PhoneNumber;
	}
	
}
