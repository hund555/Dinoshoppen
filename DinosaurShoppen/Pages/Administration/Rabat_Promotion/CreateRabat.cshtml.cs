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
    public class CreateRabatModel : PageModel
    {
        private readonly IRabatService _rabatService;

        public CreateRabatModel(IRabatService rabatService)
        {
            _rabatService = rabatService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RabatDTO Rabat { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _rabatService.AddNewRabat(Rabat);

            return RedirectToPage("/Administration/Index");
        }
    }
}
