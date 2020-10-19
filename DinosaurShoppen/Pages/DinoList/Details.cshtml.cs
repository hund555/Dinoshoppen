using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DinosaurDTO Dinosaur { get; set; }
        public void OnGet()
        {
            Dinosaur = _dinoService.GetDinoById(DinoId);
        }
    }
}
