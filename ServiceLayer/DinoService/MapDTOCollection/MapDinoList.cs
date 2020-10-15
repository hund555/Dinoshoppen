using DataLayer.Entities;
using ServiceLayer.DinoService.DTOCollection;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.DinoService.MapDTOCollection
{
    public static class MapDinoList
    {
        public static IQueryable<ListDinoDTO> MapToDinoList(this IQueryable<Dinosaur> dino)
        {
            return dino.Select(d => new ListDinoDTO
            {
                DinosaurId = d.DinosaurId,
                DinoName = d.DinoName,
                DinoPicture = d.DinoPicture,
                DinoPrice = d.DinoPrice - (d.DinoPrice / 100 * d.Promotion.PromotionRabat),

                PromotionRabat = d.Promotion.PromotionRabat,
                PromotionName = d.Promotion.PromotionName,

                DietId = d.DietId,
                DietName = d.Diet.DietName
            });
        }
    }
}
