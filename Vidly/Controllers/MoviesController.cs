using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Database;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers {

    [RoutePrefix("movies")]
    public class MoviesController : Controller {

        private MyDbContext _context;

        public MoviesController() {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult Index() {
            return View(GetData());
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1 });
            /*if (!pageIndex.HasValue) {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy)) {
                sortBy = "Name";
            }
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));*/
        }

        [HttpGet]
        [Route("new")]
        public ActionResult New() {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel {
                Movie = new Movie(),
                Genres = genres
            };
            return View("Form", viewModel);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id) {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            var genres = _context.Genres.ToList();
            if (movie == null) {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel {
                Movie = movie,
                Genres = genres
            };
            return View("Form", viewModel);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(Movie movie) {
            movie.DateAdded = DateTime.Now;
            if (movie.Id == 0) {
                _context.Movies.Add(movie);
            } else {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Route("details/{id}")]
        [HttpGet]
        public ActionResult Details(int id) {
            var movie = _context.Movies.Include(x => x.Genre).First(x => x.Id == id);
            return View(movie);
        }

        [HttpGet]
        [Route("released/{year}/{month:regex(\\d(2)):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }

        private RandomMovieViewModel GetData() {
            var movies = _context.Movies.Include(x => x.Genre).ToList();
            var viewModel = new RandomMovieViewModel {
                Movies = movies,
                Customers = null
            };
            return viewModel;
        }
    }
}