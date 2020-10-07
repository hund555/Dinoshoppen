﻿using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Dinosaur
    {
        public int DinosaurId { get; set; } //PK

        public string DinoName { get; set; }

        public double DinoWeight { get; set; } //In kg

        public double DinoLenght { get; set; } //In meters

        public double DinoHeight { get; set; } //In meters

        public double DinoPrice { get; set; }

        public int? PromotionId { get; set; } //FK

        public int DietId { get; set; } //FK

        //Navigation relations
        public Promotion Promotion { get; set; }

        public Diet Diet { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
