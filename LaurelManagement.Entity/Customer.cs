using LaurelManagement.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Entity
{
   public  class Customer:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

    }

}
