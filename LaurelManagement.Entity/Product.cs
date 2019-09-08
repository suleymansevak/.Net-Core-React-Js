using LaurelManagement.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Entity
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string UnitInStock { get; set; }
    }
}
