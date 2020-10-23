using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.EnumCollection;
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
        public uint? PageSize { get; set; }

        [Display(Name = "Filtrer på Diet")]
        [BindProperty(SupportsGet = true)]
        public int? FilterDiet { get; set; }

        [BindProperty]
        public int TotalPages { get; set; }

        [Display(Name = "Sorter efter")]
        [BindProperty(SupportsGet = true)]
        public int? OrderBy { get; set; }

        [Display(Name = "Søger på dinosaur navn")]
        [BindProperty(SupportsGet = true)]
        public string FilterName { get; set; }

        [BindProperty]
        public int DinoId { get; set; }

        [BindProperty]
        public uint Antal { get; set; }

        public void OnGet()
        {
            Options = new SortFilterPageOptions();
            DinoPromotionList = _dinoService.GetTop6PromotionDino().ToList();

            if (CurrentPage.HasValue)
            {
                Options.PageNumber = (int)CurrentPage;
            }
            if (FilterDiet.HasValue && FilterDiet <= Enum.GetNames(typeof(EnumDinoFilter)).Length && FilterDiet >= 0)
            {
                Options.FilterByDiet = (EnumDinoFilter)FilterDiet;
            }
            if (PageSize.HasValue)
            {
                Options.PageSize = (int)PageSize;
            }
            if (OrderBy.HasValue && OrderBy <= Enum.GetNames(typeof(EnumOrderDinoListByOptions)).Length && OrderBy >= 0)
            {
                Options.OrderByOptions = (EnumOrderDinoListByOptions)OrderBy;
            }

            if (string.IsNullOrEmpty(FilterName))
            {
                DinoList = _dinoService.GetFullDinoList(Options).ToList();
            }
            else
            {
                DinoList = _dinoService.GetDinoListWithNameFilter(Options, FilterName).ToList();
            }
            
            TotalPages = Options.PagesCount;
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
