using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DinoService.DTOCollection
{
    public class DinosaurDTO
    {
        public int DinosaurId { get; set; } //PK

        [Display(Name = "Dinosaur")]
        public string DinoName { get; set; }

        public string DinoPicture { get; set; }

        [Display(Name = "Vægt")]
        public double DinoWeight { get; set; } //In kg

        [Display(Name = "Længde")]
        public double DinoLenght { get; set; } //In meters

        [Display(Name = "Højde")]
        public double DinoHeight { get; set; } //In meters

        [Display(Name = "Pris")]
        public double DinoPrice { get; set; }

        public int? PromotionId { get; set; } //FK
        [Display(Name = "Kampagne")]
        public string PromotionName { get; set; }
        [Display(Name = "Rabat")]
        public int? PromotionRabat { get; set; }

        public int DietId { get; set; } //FK
        [Display(Name = "Diet")]
        public string DietName { get; set; }
    }
}
