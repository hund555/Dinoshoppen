using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Diet
    {
        public int DietId { get; set; }
        public string DietName { get; set; }


        public int DinoId { get; set; }
        public Dinosaur Dinosaur { get; set; }
    }
}
