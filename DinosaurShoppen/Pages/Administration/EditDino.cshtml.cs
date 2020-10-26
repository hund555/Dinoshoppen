using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services.ServiceInterfaces;

namespace DinosaurShoppen.Pages.Administration
{
    public class EditDinoModel : PageModel
    {
        private readonly IDinoAdminService _dinoService;
        public EditDinoModel(IDinoAdminService dinoService)
        {
            _dinoService = dinoService;
        }

        [BindProperty]
        public DinosaurDTO Dinosaur { get; set; }

        public SelectList PromotionsDDL { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? DinosaurId { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }

        public void OnGet()
        {
            Dinosaur = _dinoService.GetDinosaurDTOById((int)DinosaurId);
            PromotionsDDL = new SelectList(_dinoService.PromotionList().ToList(), "PromotionId", "PromotionName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
