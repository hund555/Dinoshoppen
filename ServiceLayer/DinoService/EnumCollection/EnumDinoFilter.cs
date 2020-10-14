using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.DinoService.EnumCollection
{
    public enum EnumDinoFilter
    {
        [Display(Name = "Alle")]
        All,

        [Display(Name = "Kødædere")]
        Carnivore,

        [Display(Name = "Planteædere")]
        Herbivore,

        [Display(Name = "Alt Spisende")]
        Omnivore
    }
}
