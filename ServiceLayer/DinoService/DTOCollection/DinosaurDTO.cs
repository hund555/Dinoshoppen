using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DinoService.DTOCollection
{
    public class DinosaurDTO
    {
        public int DinosaurId { get; set; } //PK

        public string DinoName { get; set; }

        public string DinoPicture { get; set; }

        public double DinoWeight { get; set; } //In kg

        public double DinoLenght { get; set; } //In meters

        public double DinoHeight { get; set; } //In meters

        public double DinoPrice { get; set; }

        public int? PromotionId { get; set; } //FK

        public int DietId { get; set; } //FK
        public string DietName { get; set; }
    }
}
