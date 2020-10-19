using DataLayer.Entities;
using ServiceLayer.DinoService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.DinoService.MapDTOCollection
{
    public static class MapDinosaurDTO
    {
        public static IQueryable<DinosaurDTO> MapDinoToDto(this IQueryable<Dinosaur> dino)
        {
            return dino.Select(d => new DinosaurDTO
            {
                DinosaurId = d.DinosaurId,
                DinoName = d.DinoName,
                DinoWeight = d.DinoWeight,
                DinoHeight = d.DinoHeight,
                DinoLenght = d.DinoLenght,
                DinoPrice = d.DinoPrice,
                PromotionId = d.PromotionId,
                DinoPicture = d.DinoPicture,

                DietId = d.DietId,
                DietName = d.Diet.DietName
            });
        }

    }
}
