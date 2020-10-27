using DataLayer.Entities;
using ServiceLayer.Rabat_PromotionService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Rabat_PromotionService.MapDTOCollection
{
    public static class MapRabatDTO
    {
        public static IQueryable<RabatDTO> MapRabatToDTO(this IQueryable<Rabat> rabats)
        {
            return rabats.Select(r => new RabatDTO
            {
                RabatId = r.RabatId,
                RabatName = r.RabatName,
                RabatProcent = r.RabatProcent,
                SoftDelete = r.SoftDelete
            });
        }

        public static Rabat MapDTOToRabat(this RabatDTO rabatDto)
        {
            Rabat rabat = new Rabat()
            {
                RabatId = rabatDto.RabatId,
                RabatName = rabatDto.RabatName,
                RabatProcent = rabatDto.RabatProcent,
                SoftDelete = rabatDto.SoftDelete
            };
            return rabat;
        }
    }
}
