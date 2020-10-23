using DataLayer.Entities;
using ServiceLayer.DinoService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.DinoService.MapDTOCollection
{
    public static class MapPromotionList
    {
        public static IQueryable<PromotionListDTO> MapPromotionListToDTO(this IQueryable<Promotion> promotions)
        {
            return promotions.Select(p => new PromotionListDTO
            {
                PromotionId = p.PromotionId,
                PromotionName = p.PromotionName
            });
        }
    }
}
