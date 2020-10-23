using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services.ServiceInterfaces;

namespace DinosaurShoppen.Pages.DinoList
{
    public class DetailsModel : PageModel
    {
        private readonly IDinoService _dinoService;

        public DetailsModel(IDinoService dinoService)
        {
            _dinoService = dinoService;
        }

        [BindProperty(SupportsGet = true)]
        public int DinoId { get; set; }

        [BindProperty]
        public uint Antal { get; set; }

        public DinosaurDTO Dinosaur { get; set; }
        public void OnGet()
        {
            Dinosaur = _dinoService.GetDinoById(DinoId);

            Dinosaur.DinoPrice -= Dinosaur.DinoPrice / 100 * Dinosaur.PromotionRabat;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int? myId = HttpContext.Session.GetInt32("_customerId");

            if (myId == null || myId == 0)
            {
                return RedirectToPage("/CustomerPages/Login");
            }
            await _dinoService.AddDinoToCart((int)myId, DinoId, (int)Antal);
            return RedirectToAction("./");
        }
    }
}
