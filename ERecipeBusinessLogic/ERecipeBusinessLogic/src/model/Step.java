package model;

public class Step 
{
	public int Id;
	public String Description;
	
	public Step(int Id, String Description)
	{
		this.Id = Id;
		this.Description = Description;
	}
	
	public int getId()
	{
		return Id;
	}
	public void setId(int Id)
	{
		this.Id = Id;
	}
	public String getDescription()
	{
		return Description;
	}
	public void setDescription(String Description)
	{
		this.Description = Description;
	}
}
