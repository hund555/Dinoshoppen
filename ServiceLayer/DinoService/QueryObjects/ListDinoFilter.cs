using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.EnumCollection;
using System;
using System.Linq;

namespace ServiceLayer.DinoService.QueryObjects
{
    public static class ListDinoFilter
    {
        public static IQueryable<ListDinoDTO> FilterListDinoBy(this IQueryable<ListDinoDTO> dinoList, EnumDinoFilter diet)
        {
            switch (diet)
            {
                case EnumDinoFilter.All:
                    return dinoList;

                case EnumDinoFilter.Carnivore:
                    return dinoList.Where(d => d.DietId == 1);

                case EnumDinoFilter.Herbivore:
                    return dinoList.Where(d => d.DietId == 2);

                case EnumDinoFilter.Omnivore:
                    return dinoList.Where(d => d.DietId == 3);

                default:
                    throw new ArgumentOutOfRangeException(nameof(diet), diet, null);
            }
        }
    }
}
