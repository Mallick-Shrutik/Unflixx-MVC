using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using Unflixx.Dtos;
using Unflixx.Models;


//this is an api file
//we need to test api using Postman Rest Client
//tested the GET,POST actions and now Need to check the DELETE and PUT options functions

namespace Unflixx.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);


            return Ok(customerDtos);
        }

        //GET /api/customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer , CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        //public CustomerDto can also be used but it will return Status 200 but for Post Action, 201(Created) is the actual required
        //so we use IHttpActionResult which is similar to ActionResult in MVC
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); //this is the helper method of IHttpActionResult and is a class of that
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //as per RESTful covention Uri(Unified Resource Identifier) is returned
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
