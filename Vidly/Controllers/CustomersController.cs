using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Database;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers {

    [RoutePrefix("customers")]
    public class CustomersController : Controller {

        private MyDbContext _context;

        public CustomersController() {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult Index() {
            return View(GetData());
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id) {
            var customer = GetData().Customers.Find(x => x.Id == id);
            if (customer == null) {
                customer = new Customer { Name = "Ops!" };
            }
            return View(customer);
        }

        private RandomMovieViewModel GetData() {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var viewModel = new RandomMovieViewModel {
                Movies = null,
                Customers = customers
            };
            return viewModel;
        }
    }
}