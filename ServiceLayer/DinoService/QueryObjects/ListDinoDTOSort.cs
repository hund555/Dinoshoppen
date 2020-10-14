using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.EnumCollection;
using System;
using System.Linq;

namespace ServiceLayer.DinoService.QueryObjects
{
    public static class ListDinoDTOSort
    {
        public static IQueryable<ListDinoDTO> OrderDinoListBy(this IQueryable<ListDinoDTO> dinoList, EnumOrderDinoListByOptions orderOptions)
        {
            switch (orderOptions)
            {
                case EnumOrderDinoListByOptions.ByNewest:
                    return dinoList.OrderByDescending(d => d.DinosaurId);

                case EnumOrderDinoListByOptions.ByOldest:
                    return dinoList.OrderBy(d => d.DinosaurId);

                case EnumOrderDinoListByOptions.ByPriceASC:
                    return dinoList.OrderBy(d => d.DinoPrice);

                case EnumOrderDinoListByOptions.ByPriceDES:
                    return dinoList.OrderByDescending(d => d.DinoPrice);

                case EnumOrderDinoListByOptions.ByName:
                    return dinoList.OrderBy(d => d.DinoName);

                case EnumOrderDinoListByOptions.ByPromotion:
                    return dinoList.OrderBy(d => d.PromotionRabat);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderOptions), orderOptions, null);
            }
        }
    }
}
