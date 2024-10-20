namespace Library.Models;

public class UserModel(int id, string firstName, string lastName, string email, string address) : JsonEntryModel(id)
{
	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; } = lastName;
	public string Email { get; set; } = email;
	public string Address { get; set; } = address;

}