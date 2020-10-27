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
    public class EditRabatModel : PageModel
    {
        private readonly IRabatService _rabatService;

        public EditRabatModel(IRabatService rabatService)
        {
            _rabatService = rabatService;
        }

        [BindProperty]
        public RabatDTO Rabat { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rabat = _rabatService.GetRabatDTOById((int)id);

            if (Rabat == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _rabatService.UpdateRabat(Rabat);

            return RedirectToPage("./Index");
        }
    }
}
