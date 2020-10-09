using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Promotion
    {
        public int PromotionId { get; set; } //PK

        public string PromotionName { get; set; }

        public int PromotionRabat { get; set; }

        public bool SoftDelete { get; set; }

        //Navigation relation
        public List<Dinosaur> Dinosaurs { get; set; }
    }
}
