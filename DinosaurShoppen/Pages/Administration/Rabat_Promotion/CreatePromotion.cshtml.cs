using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Rabat_PromotionService.Services.Interfaces;
using ServiceLayer.Rabat_PromotionService.DTOCollection;

namespace DinosaurShoppen.Pages.Administration.Rabat_Promotion
{
    public class CreatePromotionModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public CreatePromotionModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PromotionDTO Promotion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _promotionService.AddNewPromotion(Promotion);

            return RedirectToPage("/Administration/Index");
        }
    }
}
