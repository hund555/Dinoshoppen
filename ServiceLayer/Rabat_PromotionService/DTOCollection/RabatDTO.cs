using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.Rabat_PromotionService.DTOCollection
{
    public class RabatDTO
    {
        public int RabatId { get; set; }
        [Display(Name = "Rabat prosent")]
        public int RabatProcent { get; set; }
        [Display(Name = "RabatKode")]
        public string RabatName { get; set; }
        public bool SoftDelete { get; set; }
    }
}
