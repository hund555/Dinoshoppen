﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Rabat
    {
        public int RabatId { get; set; } //PK

        public string RabatName { get; set; }

        public int RabatProcent { get; set; }

        public bool SoftDelete { get; set; }

        //Navigation relation
        public List<Cart> Carts { get; set; }
    }
}
