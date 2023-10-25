using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _dbContext;
        public AuthorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Details()
        {
            var authors = _dbContext.Authors
                .Select(b => new AuthorViewModel
                {
                    AuthorId = b.AuthorId,
                    Name = b.Name
                })
                .ToList();

            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]// Responds to HTTP POST requests. Submitting data to the server: Submitting a form on a web page.
        // Data sent to the server in the HTTP POST request: Author Object
        public IActionResult Create(Author author)
        {
                _dbContext.Authors.Add(author);       
                _dbContext.SaveChanges();
                return RedirectToAction("Details");
        }

        [HttpPost]
        public IActionResult Delete(int authorId)
        {
            try
            {
                var author = _dbContext.Authors.Find(authorId);
                if (author != null)
                {
                    _dbContext.Authors.Remove(author);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction("Details"); // Redirect to the list of authors after deletion
        } 
    }
}