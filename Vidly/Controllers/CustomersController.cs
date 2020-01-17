using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers {

    [RoutePrefix("customers")]
    public class CustomersController : Controller {

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
            var customers = new List<Customer> {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
            var viewModel = new RandomMovieViewModel {
                Movies = null,
                Customers = customers
            };
            return viewModel;
        }
    }
}