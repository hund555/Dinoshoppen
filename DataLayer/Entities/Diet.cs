﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Diet
    {
        public int DietId { get; set; }

        public string DietName { get; set; }

        //Navigation relation
        public Dinosaur Dinosaur { get; set; }
    }
}
