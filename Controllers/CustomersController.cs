using MovieApp.Contexts;
using MovieApp.Models;
using MovieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        private LocalDatabase context = new LocalDatabase();

        // GET: Customers
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                return RedirectToAction("GetCustomer", new { id = id.Value });
            }

            var customers = context.Customers.Take(100);
            var customersViewModel = new CustomersViewModel
            {
                Customers = customers
            };

            return View(customersViewModel);
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = context.Customers
                .Where(c => c.Id == id)
                .DefaultIfEmpty(null)
                .FirstOrDefault();
            if (customer is null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}