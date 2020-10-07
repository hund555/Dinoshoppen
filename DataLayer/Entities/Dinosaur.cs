namespace DataLayer.Entities
{
    public class Dinosaur
    {
        public int DinosaurId { get; set; } //PK
        public string DinoName { get; set; }
        public decimal DinoWeight { get; set; } //In kg
        public decimal DinoLenght { get; set; } //In meters
        public decimal DinoHeight { get; set; } //In meters
        public decimal DinoPrice { get; set; }
        public int? PromotionId { get; set; }



        public Diet Diet { get; set; }
    }
}
