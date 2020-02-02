using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Database;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api {

    [RoutePrefix("api/customers")]
    public class CostumersController : ApiController {

        private MyDbContext _context;

        public CostumersController() {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        //  GET /api/customers
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCustomers() {
            var customerDTO = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customerDTO);
        }

        //  GET /api/customers/1
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCustomer(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //  POST /api/customers
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        //  PUT /api/customers/1
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null) {
                return NotFound();
            }
            Mapper.Map(customerDTO, customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        //  DELETE  /api/customers/1
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCustomer(int id) {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
