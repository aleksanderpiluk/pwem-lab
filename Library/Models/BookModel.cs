namespace Library.Models;

public class BookModel(int id, string isbn, string title, string author, string genre, string type, int available, string imageUrl) : JsonEntryModel(id)
{
	public string ISBN { get; set; } = isbn;
	public string Title { get; set; } = title;
	public string Author { get; set; } = author;
	public string Genre { get; set; } = genre;
	public string Type { get; set; } = type;

	public string ImageUrl { get; set; } = imageUrl;
	public int AllCopies { get; set; } = available;
	public int Available { get; set; } = available;

	public bool Borrow()
	{
		if (Available == 0)
		{
			return false;
		}
		Available -= 1;
		return true;
	}

	public bool Return()
	{
		if (Available + 1 > AllCopies)
		{
			return false;
		}
		Available += 1;
		return true;
	}
}