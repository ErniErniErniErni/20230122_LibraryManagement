// BookViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
	public class BookViewModel
	{
		[Display(Name = "Book ID")]
		public int BookId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Author Name is required.")]
		public string AuthorName { get; set; }

		[Required(ErrorMessage = "Branch Name is required.")]
		public string BranchName { get; set; }
	}

}
