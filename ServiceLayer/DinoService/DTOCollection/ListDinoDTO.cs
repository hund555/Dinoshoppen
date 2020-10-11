﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DinoService.DTOCollection
{
    public class ListDinoDTO
    {
        public int DinosaurId { get; set; }
        public string DinoName { get; set; }
        public double DinoPrice { get; set; }


        public int PromotionRabat { get; set; }
        public string PromotionName { get; set; }

        public string DietName { get; set; }
    }
}