using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _dbContext;
        public CustomerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Details()
        {
            var customers = _dbContext.Customers
                .Select(b => new CustomerViewModel
                {
                    CustomerId = b.CustomerId,
                    Name = b.Name
                })
                .ToList();

            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer custmer)
        {
            _dbContext.Customers.Add(custmer);       
            _dbContext.SaveChanges();
            return RedirectToAction("Details");
        }  
    }
}