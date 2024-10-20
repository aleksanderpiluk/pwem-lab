using Library.Models;
using Library.Services;

namespace Library.Repositories;

public class LibraryRepository(JsonService jsonService)
{
	private readonly JsonService _jsonService = jsonService;

	public List<BookModel> GetBookList()
	{
		_jsonService.SetFilePath("books.json");
		return _jsonService.GetAll<BookModel>();
	}
	public List<LoanModel> GetLoanList()
	{
		_jsonService.SetFilePath("loans.json");
		return _jsonService.GetAll<LoanModel>();
	}

	public List<UserModel> GetUserList()
	{
		_jsonService.SetFilePath("users.json");

		return _jsonService.GetAll<UserModel>().Cast<UserModel>().ToList();
	}

	public UserModel? GetUser(int userId)
	{
		return GetUserList().Find(user => user.id == userId);
	}

	public List<LoanModel> ReservationList()
	{
		return GetLoanList().Where(x => x.Status == LoanStatus.Reserved).ToList();
	}


	public List<BookModel> GetLoanedBooks(List<LoanModel> loans)
	{
		return GetBookList().Where(book => loans.Find(loan => loan.BookId == book.id) != null).ToList();
	}


	public List<BookModel> GetFilteredBooks(List<BookModel> books, string text, int searchType)
	{
		switch (searchType)
		{
			// title
			case 0:
				{
					return books.Where(book => book.Title.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
				}
			// Author
			case 1:
				{
					return books.Where(book => book.Author.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
				}
			// Genre
			case 2:
				{
					return books.Where(book => book.Genre.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
				}
			default:
				{
					return books.Where(book => book.Title.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList()
						.Concat(books.Where(book => book.Author.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList())
						.Concat(books.Where(book => book.Genre.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList())
						.Distinct()
						.ToList();
				}
		}

	}

	public List<LoanModel> GetFilteredLoans(List<BookModel> books, List<LoanModel> loans, string lender, string bookFilterText, DateOnly startDate, DateOnly endDate)
	{
		List<UserModel> user = GetUserList().Where(user =>
			lender.Contains(user.FirstName) ||
			lender.Contains(user.LastName) ||
			user.LastName.Contains(lender) ||
			user.FirstName.Contains(lender)

		).ToList();

		books = GetFilteredBooks(books, bookFilterText, 3);

		loans = loans.Where(
			loan => loan.LoanEndDate.CompareTo(startDate) >= 0 &&
			loan.LoanEndDate.CompareTo(endDate) <= 0 &&
			books.Find(book => book.id == loan.BookId) != null
		).ToList();

		return loans;
	}

	public List<LoanModel> GetUserLoans(int userId)
	{
		return GetLoanList().Where(loan => loan.LenderId == userId).ToList();
	}

}