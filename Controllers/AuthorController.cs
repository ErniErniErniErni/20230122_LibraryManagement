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

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _dbContext.Authors.Add(author);       
            _dbContext.SaveChanges();
            return RedirectToAction("Details");
        }  
    }
}