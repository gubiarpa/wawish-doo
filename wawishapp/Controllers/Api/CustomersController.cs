using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using wawishapp.Controllers.Base;
using wawishapp.Dtos;
using wawishapp.Models;

namespace wawishapp.Controllers.Api
{
    public class CustomersController : BasicApiController
    {
        // GET /api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/Customers/1
        public CustomerDto GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id; // ◄ Incluye el Id generado por DB

            //return customerDto; // ◄ Cuando devuelve Customer
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null) return NotFound(); 

            // Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); // ◄ Reemplaza "Assign"
            Mapper.Map(customerDto, customerInDb); // ▲ Omite los tipos porque es innecesario

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null) return /*BadRequest()*/;

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            //return Ok();
        }
    }
}
