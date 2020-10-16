using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services;
using ServiceLayer.DinoService.Services.ServiceInterfaces;

namespace DinosaurShoppen.Pages.DinoList
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDinoService _dinoService;

        public IndexModel(ILogger<IndexModel> logger, IDinoService dinoService)
        {
            _logger = logger;
            _dinoService = dinoService;
        }

        public IList<ListDinoDTO> DinoPromotionList { get; set; }
        public IList<ListDinoDTO> DinoList { get; set; }

        public SortFilterPageOptions Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CurrentPage { get; set; }

        [Display(Name = "Side størelse")]
        [BindProperty(SupportsGet = true)]
        public int? PageSize { get; set; }

        [Display(Name = "Filtrer på Diet")]
        [BindProperty(SupportsGet = true)]
        public int? FilterDiet { get; set; }

        [Display(Name = "Sorter efter")]
        [BindProperty(SupportsGet = true)]
        public int? OrderBy { get; set; }

        [Display(Name = "Søger på dinosaur navn")]
        [BindProperty(SupportsGet = true)]
        public string FilterName { get; set; }

        [BindProperty]
        public int DinoId { get; set; }

        public void OnGet()
        {
            Options = new SortFilterPageOptions();
            DinoPromotionList = _dinoService.GetTop6PromotionDino().ToList();
            DinoList = _dinoService.GetFullDinoList(Options).ToList();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
