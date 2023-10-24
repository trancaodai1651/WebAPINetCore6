using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPINetCore6.Models
{
    public class CustomerVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class Customer : CustomerVM{
        public Guid Id { get; set; }
    }
}