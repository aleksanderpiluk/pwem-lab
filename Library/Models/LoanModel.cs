namespace Library.Models;


public enum LoanStatus
{
	Reserved,
	Loaned,
	Returned,
	Lost
}

public class LoanModel : JsonEntryModel
{
	public DateTime LoanStartDate { get; set; }
	public DateTime LoanEndDate { get; set; }

	public DateTime ReturnDate { get; set; }
	public DateTime ReservationDate { get; set; }
	public int BookId { get; set; }
	public int LenderId { get; set; }

	public string LenderFirstName { get; set; }
	public string LenderLastName { get; set; }

	public string BookTitle { get; set; }
	public string BookImageUrl { get; set; }

	public LoanStatus Status { get; set; }


	public LoanModel(int id, UserModel user, BookModel book) : base(id)
	{
		BookId = book.id;
		LenderId = user.id;
		LenderFirstName = user.FirstName;
		LenderLastName = user.LastName;
		BookTitle = book.Title;
		BookImageUrl = book.ImageUrl;

		Reserve();
	}

	public void Reserve()
	{
		Status = LoanStatus.Reserved;
		ReservationDate = new DateTime();
	}

	public bool Borrow(BookModel book)
	{
		if (book.Borrow())
		{
			Status = LoanStatus.Loaned;
			LoanStartDate = new DateTime();
			LoanEndDate = LoanStartDate.AddDays(30);
			return true;
		}
		return false;
	}

	public bool Return(BookModel book)
	{
		if (book.Return())
		{
			Status = LoanStatus.Returned;
			ReturnDate = new DateTime();
			return true;
		}

		return false;
	}


	public void CheckAsLost(BookModel book)
	{
		Status = LoanStatus.Lost;
		book.AllCopies -= 1;
	}
}