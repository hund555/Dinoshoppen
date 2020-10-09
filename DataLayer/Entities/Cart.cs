using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace DataLayer.Entities
{
    public class Cart
    {
        public int CustomerId { get; set; } //FK

        public int? DinosaurId { get; set; } //FK

        public int? RabatId { get; set; } //FK

        public double TotalPrice { get; set; }

        //Navigation relations
        public Customer Customer { get; set; }

        public Dinosaur Dinosaur { get; set; }

        public Rabat Rabat { get; set; }
    }
}
