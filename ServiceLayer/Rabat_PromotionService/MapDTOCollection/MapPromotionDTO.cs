using DataLayer.Entities;
using ServiceLayer.Rabat_PromotionService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Rabat_PromotionService.MapDTOCollection
{
    public static class MapPromotionDTO
    {
        public static IQueryable<PromotionDTO> MapPromotionToDTO(this IQueryable<Promotion> promotions)
        {
            return promotions.Select(p => new PromotionDTO
            {
                PromotionId = p.PromotionId,
                PromotionName = p.PromotionName,
                PromotionRabat = p.PromotionRabat,
                SoftDelete = p.SoftDelete
            });
        }

        public static Promotion MapDTOToPromotion(this PromotionDTO dto)
        {
            Promotion promotion = new Promotion()
            {
                PromotionId = dto.PromotionId,
                PromotionName = dto.PromotionName,
                PromotionRabat = dto.PromotionRabat,
                SoftDelete = dto.SoftDelete
            };
            return promotion;
        }
    }
}
