using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}