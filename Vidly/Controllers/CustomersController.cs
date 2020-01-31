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
        [Route("new")]
        public ActionResult New() {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("Form", viewModel);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id) {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customer
            };
            return View("Form", viewModel);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(Customer customer) {
            if (!ModelState.IsValid) {
                var viewModel = new CustomerFormViewModel {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Form", viewModel);
            }
            if (customer.Id == 0) {
                _context.Customers.Add(customer);
            } else {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id) {
            var customer = GetData().Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) {
                return HttpNotFound();
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