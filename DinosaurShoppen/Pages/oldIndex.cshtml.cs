using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.Services.ServiceInterfaces;

namespace DinosaurShoppen.Pages
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

        public IEnumerable<ListDinoDTO> DinoPromotionList { get; set; }

        public void OnGet()
        {
            DinoPromotionList = _dinoService.GetTop6PromotionDino();
        }
    }
}
