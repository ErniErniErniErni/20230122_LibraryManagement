using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
	public class AuthorViewModel
	{
		[Required(ErrorMessage = "AuthorId is required")]
		[Range(1, int.MaxValue, ErrorMessage = "AuthorId must be a positive integer")]
		public int AuthorId { get; set; }
		[Required(ErrorMessage = "Name is required")]
    	[StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
		public string Name { get; set; }
	}
}