using DataLayer;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services;
using System;

namespace Dinoshoppen
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DinoDbContext context = new DinoDbContext())
            {
                DinoService dino = new DinoService(context);

                foreach (ListDinoDTO dinosaur in dino.GetTop6PromotionDino())
                {
                    Console.WriteLine($"{dinosaur.DinoName} - Type: {dinosaur.DietName} - Price: {(dinosaur.DinoPrice - (dinosaur.DinoPrice / 100 * dinosaur.PromotionRabat)).ToString("c")} - Promotion: {dinosaur.PromotionName}");
                }
            }
        }
    }
}
