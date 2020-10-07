using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mail { get; set; }

        //Navigation relation
        public List<Cart> Carts { get; set; }
    }
}
