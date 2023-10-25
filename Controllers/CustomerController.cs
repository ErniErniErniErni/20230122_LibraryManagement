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

        [HttpPost]// Responds to HTTP POST requests. Submitting data to the server: Submitting a form on a web page.
        // Data sent to the server in the HTTP POST request: Customer Object
        public IActionResult Create(Customer custmer)
        {
            _dbContext.Customers.Add(custmer);       
            _dbContext.SaveChanges();
            return RedirectToAction("Details");
        }  

        [HttpPost]
        public IActionResult Delete(int customerId)
        {
            try
            {
                var customer = _dbContext.Customers.Find(customerId);
                if (customer != null)
                {
                    _dbContext.Customers.Remove(customer);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction("Details"); // Redirect to the list of customers after deletion
        }

    }
}