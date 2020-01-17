using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers {

    [RoutePrefix("movies")]
    public class MoviesController : Controller {

        [HttpGet]
        public ActionResult Index(int? pageIndex, string sortBy) {
            return View(GetData());
            /*if (!pageIndex.HasValue) {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy)) {
                sortBy = "Name";
            }
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));*/
        }

        [Route("random")]
        [HttpGet]
        public ActionResult Random() {
            var movie = new Movie("Shrek!");
            var customers = new List<Customer> { 
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel {
                Movies = new List<Movie> { movie },
                Customers = customers
            };
            return View(viewModel);
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1 });
        }

        [Route("edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id) {
            return Content("Id= " + id);
        }

        [HttpGet]
        [Route("released/{year}/{month:regex(\\d(2)):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }

        private RandomMovieViewModel GetData() {
            var movies = new List<Movie> {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Star Wars" }
            }; var viewModel = new RandomMovieViewModel {
                Movies = movies,
                Customers = null
            };
            return viewModel;
        }
    }
}