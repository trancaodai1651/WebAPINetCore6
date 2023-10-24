using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPINetCore6.Models;

namespace WebAPINetCore6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> customers = new List<Customer>();

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(customers);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(string id){
            try{
                //LINQ [Object] Query
            var customer = customers.SingleOrDefault(ct => ct.Id == Guid.Parse(id));
            if(customer == null){
                return NotFound();
            }
            return Ok(customer);
            }
            catch{
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(CustomerVM customeVM){

            var customer = new Customer{
                Id = Guid.NewGuid(),
                Name = customeVM.Name,
                Address = customeVM.Address,
                Email = customeVM.Email,
                Phone = customeVM.Phone
            };

            //Add customer
            customers.Add(customer);
            return Ok(new{
                Success = true, Data = customer
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Customer customerEdit){
            try{
                //LINQ [Object] Query
                var customer = customers.SingleOrDefault(ct => ct.Id == Guid.Parse(id));
                if(customer == null){
                    return NotFound();
                }

                //Check id
                if(id != customer.Id.ToString()){
                    return BadRequest();
                }

                //Update customer
                customer.Name = customerEdit.Name;
                customer.Address = customerEdit.Address;
                customer.Email = customerEdit.Email;
                customer.Phone = customerEdit.Phone;
                return Ok(new{
                    Success = true, Data = customer
                });
            }
            catch{
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id){
            try{
                //LINQ [Object] Query
                var customer = customers.SingleOrDefault(ct => ct.Id == Guid.Parse(id));
                if(customer == null){
                    return NotFound();
                }

                //Delete customer
                customers.Remove(customer);
                return Ok();
            }
            catch{
                return BadRequest();
            }
        }
            
    }
}