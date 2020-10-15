using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CustomerService.DTOCollection
{
    public class FullCustomerDTO
    {
        public int CustomerId { get; set; } 

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mail { get; set; }

        public ICollection<Cart> Card { get; set; }
    }
}
