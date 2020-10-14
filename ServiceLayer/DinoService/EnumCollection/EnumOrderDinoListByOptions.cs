using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DinoService.EnumCollection
{
    public enum EnumOrderDinoListByOptions
    {
        [Display(Name = "Nyeste")]
        ByNewest,
        [Display(Name = "Ælste")]
        ByOldest,
        [Display(Name = "Pris stigende")]
        ByPriceASC,
        [Display(Name = "Pris faldene")]
        ByPriceDES,
        [Display(Name = "Navn")]
        ByName,
        [Display(Name = "Tilbud")]
        ByPromotion
    }
}
