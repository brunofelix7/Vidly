using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Database;
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
        public ActionResult Index(int? pageIndex, string sortBy) {
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

        [Route("details/{id}")]
        [HttpGet]
        public ActionResult Details(int id) {
            var movie = _context.Movies.Include(x => x.Genre).First(x => x.Id == id);
            return View(movie);
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
            var movies = _context.Movies.Include(x => x.Genre).ToList();
            var viewModel = new RandomMovieViewModel {
                Movies = movies,
                Customers = null
            };
            return viewModel;
        }
    }
}