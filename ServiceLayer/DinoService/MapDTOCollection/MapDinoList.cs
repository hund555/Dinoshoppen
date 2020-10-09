using DataLayer.Entities;
using ServiceLayer.DinoService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                DinoPrice = d.DinoPrice,

                PromotionRabat = d.Promotion.PromotionRabat,
                PromotionName = d.Promotion.PromotionName,

                DietName = d.Diet.DietName
            });
        }
    }
}
