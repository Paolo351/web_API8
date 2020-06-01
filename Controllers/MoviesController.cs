using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_API8.Models;
using web_API8.ViewModels;

namespace web_API8.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        [Route("random")]
        public IActionResult random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);


            //return View(movie);
            //return Content("Hello World!");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        }

    

    [Route("edit")]
        public IActionResult edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("index")]
        //movies
        public IActionResult index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("released")]
        public IActionResult released(int year, int month)
        {
            int year_2 = 0;
            int month_2 = 0;
            if (year < 2030 && year > 1000 && month > 0 && month < 13)
            {
                year_2 = year;
                month_2 = month;
            }
            return Content(year_2 + "/" + month_2);
        }
    }
}
