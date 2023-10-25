using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Details()
        {
            var books = _dbContext.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .Select(b => new BookViewModel
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    AuthorName = b.Author.Name,
                    BranchName = b.LibraryBranch.BranchName
                })
                .ToList();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]// Responds to HTTP POST requests. Submitting data to the server: Submitting a form on a web page.
        // Data sent to the server in the HTTP POST request: BookViewModel Object
        public IActionResult Create(BookViewModel bookViewModel)
        {
            // Create a new Book
            var book = new Book
            {
                BookId = bookViewModel.BookId,
                Title = bookViewModel.Title
            };

            // Check if the author with the chosen name already exists
            Author author = _dbContext.Authors.FirstOrDefault(a => a.Name == bookViewModel.AuthorName);
            if (author == null)
            {
                // Author doesn't exist, create a new one
                author = new Author { Name = bookViewModel.AuthorName };
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges(); // Save the new author
            }

            // Check if the branch with the chosen name already exists
            LibraryBranch branch = _dbContext.LibraryBranches.FirstOrDefault(b => b.BranchName == bookViewModel.BranchName);
            if (branch == null)
            {
                // Branch doesn't exist, create a new one
                branch = new LibraryBranch { BranchName = bookViewModel.BranchName };
                _dbContext.LibraryBranches.Add(branch);
                _dbContext.SaveChanges(); // Save the new branch
            }

            // Set AuthorId and LibraryBranchId based on existing or new records
            book.AuthorId = author.AuthorId;
            book.LibraryBranchId = branch.LibraryBranchId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return RedirectToAction("Details");
        }

        [HttpPost]
        public IActionResult Delete(int bookId)
        {
            try
            {
                var book = _dbContext.Books.Find(bookId);
                if (book != null)
                {
                    _dbContext.Books.Remove(book);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction("Details"); // Redirect to the list of books after deletion
        }

    }
}
