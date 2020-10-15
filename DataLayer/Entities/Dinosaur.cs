using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Dinosaur
    {
        public int DinosaurId { get; set; } //PK

        public string DinoName { get; set; }

        /// <summary>
        /// In kg
        /// </summary>
        public double DinoWeight { get; set; } //In kg

        /// <summary>
        /// In meters
        /// </summary>
        public double DinoLenght { get; set; } //In meters

        /// <summary>
        /// In meters
        /// </summary>
        public double DinoHeight { get; set; } //In meters

        /// <summary>
        /// In DKK
        /// </summary>
        public double DinoPrice { get; set; }

        public string DinoPicture { get; set; }

        public int? PromotionId { get; set; } //FK

        public int DietId { get; set; } //FK

        //Navigation relations
        public Promotion Promotion { get; set; }

        public Diet Diet { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
