using MovieApp.Models;
using MovieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek 2: Electric Boogaloo" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1", Id = 1 },
                new Customer { Name = "Customer 2", Id = 2 },
                new Customer { Name = "Customer 3", Id = 3 }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id = {id}");
        }

        public ActionResult Index(int? page, string sortBy)
        {
            page = page ?? 1;
            sortBy = sortBy ?? "Name";

            return Content($"page = {page}<br>sortBy = {sortBy}");
        }

        [Route("movies/released/{year:regex(\\d{4}):range(1900, 2019)}/{month:regex(\\d{1,2})}:range(1,12)")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Json(new
            {
                year = year,
                month = month
            }, JsonRequestBehavior.AllowGet);
        }
        
    }
}