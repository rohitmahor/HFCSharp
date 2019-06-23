using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Index
        public ViewResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var movie = GetMovies();

            return View(movie);
        }

        //Return List of movies
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Name="Shrek", Id=1},
                new Movie{Name="Wall-e", Id=2}
            };
        }

        //GET: Movie/Details
        public ActionResult Details(int? id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            if (movie == null|| id == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek !"};

            var customers = new List<Customer>
            {
                new Customer {Name = "customer 1"},
                new Customer {Name = "customer 2"}
            };

            var viewModel = new RandomMovieViewModel { Customers = customers, Movie = movie };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }


        [Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(String.Format("Year = {0} and Month = {1}", year, month));
        }
    }
}