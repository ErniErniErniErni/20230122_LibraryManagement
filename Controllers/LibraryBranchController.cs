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

        [HttpPost]// Responds to HTTP POST requests. Submitting data to the server: Submitting a form on a web page.
        // Data sent to the server in the HTTP POST request: LibraryBranch Object
        public IActionResult Create(LibraryBranch libraryBranch)
        {
            _dbContext.LibraryBranches.Add(libraryBranch);       
            _dbContext.SaveChanges();
            return RedirectToAction("Details");
        }  

        [HttpPost]
        public IActionResult Delete(int branchId)
        {
            try
            {
                var branch = _dbContext.LibraryBranches.Find(branchId);
                if (branch != null)
                {
                    _dbContext.LibraryBranches.Remove(branch);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction("Details"); // Redirect to the list of library branches after deletion
        }

    }
}