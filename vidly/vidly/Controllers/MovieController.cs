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
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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
            return _context.Movies.ToList();
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

        public ActionResult New()
        {
            var movie = new Movie
            {
                NumStocks = 0,
                ReleaseDate = DateTime.Now,
                DateAdded = DateTime.Now
            };
            return View(movie);
        }

        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null || id == null)
            {
                return HttpNotFound();
            }

            return View("New", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("New", movie);
            }

            if (movie == null)
            {
                return HttpNotFound();
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                if (movieInDb == null)
                    return HttpNotFound();

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.NumStocks = movie.NumStocks;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(String.Format("Year = {0} and Month = {1}", year, month));
        }
    }
}