using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Rabat_PromotionService.Services.Interfaces;
using ServiceLayer.Rabat_PromotionService.DTOCollection;

namespace DinosaurShoppen.Pages.Administration.Rabat_Promotion
{
    public class EditPromotionModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public EditPromotionModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty]
        public PromotionDTO Promotion { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Promotion = _promotionService.GetPromotionDTOById((int)id);

            if (Promotion == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _promotionService.UpdatePromotion(Promotion);

            return RedirectToPage("/Administration/Index");
        }
    }
}
