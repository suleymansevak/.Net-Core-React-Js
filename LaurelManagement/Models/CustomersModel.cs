using LaurelManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaurelManagement.Models
{
    public class CustomersModel
    {
        public List<Customer> customerList { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }
}
