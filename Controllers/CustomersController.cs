using MovieApp.Models;
using MovieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        private Dictionary<int, Customer> CustomersDict { get; } = new Dictionary<int, Customer>
            {
                { 1, new Customer { Name = "Aaron", Id = 1 } },
                { 2, new Customer { Name = "Dillon", Id = 2 } },
                { 3, new Customer { Name = "Ben", Id = 3 } },
            };

        // GET: Customers
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                return RedirectToAction("GetCustomer", new { id = id.Value });
            }

            var customersViewModel = new CustomersViewModel
            {
                Customers = CustomersDict.Values
            };

            return View(customersViewModel);
        }

        public ActionResult GetCustomer(int id)
        {
            Customer customer;
            if (!CustomersDict.TryGetValue(id, out customer))
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}