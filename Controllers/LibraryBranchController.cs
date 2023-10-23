using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly AppDbContext _dbContext;
        public LibraryBranchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Details()
        {
            var branches = _dbContext.LibraryBranches
                .Select(b => new LibraryBranchViewModel
                {
                    LibraryBranchId = b.LibraryBranchId,
                    BranchName = b.BranchName
                })
                .ToList();

            return View(branches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibraryBranch libraryBranch)
        {
            _dbContext.LibraryBranches.Add(libraryBranch);       
            _dbContext.SaveChanges();
            return RedirectToAction("Details");
        }  
    }
}