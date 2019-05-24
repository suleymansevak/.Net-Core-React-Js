using LaurelManagement.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Entity
{
  public  class User: IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
