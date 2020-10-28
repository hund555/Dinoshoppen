using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.Rabat_PromotionService.DTOCollection
{
    public class PromotionDTO
    {
        public int PromotionId { get; set; }

        [Display(Name = "Kampagne")]
        public string PromotionName { get; set; }

        [Display(Name = "Kampagne rabat")]
        public int PromotionRabat { get; set; }
        public bool SoftDelete { get; set; }
    }
}
