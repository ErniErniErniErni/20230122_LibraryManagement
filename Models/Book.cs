// Book.cs
public class Book
{
     public int BookId { get; set; }
     public string Title { get; set; }
     public int AuthorId { get; set; }
     public int LibraryBranchId { get; set; }

     // Navigation properties
    public Author Author { get; set; }
    public LibraryBranch LibraryBranch { get; set; }
}
