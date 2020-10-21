using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CustomerService.DTOCollection;
using ServiceLayer.CustomerService.Services.Interfaces;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.EnumCollection;
using ServiceLayer.DinoService.Services;
using ServiceLayer.DinoService.Services.ServiceInterfaces;

namespace DinosaurShoppen.Pages.Administration
{
    public class IndexModel : PageModel
    {
        private readonly IDinoAdminService _dinoService;
        private readonly ICustomerServiceAdmin _adminService;

        public IndexModel(IDinoAdminService dinoService, ICustomerServiceAdmin serviceAdmin)
        {
            _dinoService = dinoService;
            _adminService = serviceAdmin;
        }

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

        public IList<DinosaurDTO> AllDinosaurs { get; set; }

        [BindProperty]
        public DinosaurDTO EditThisDino { get; set; }

        public IList<FullCustomerDTO> AllCustomers { get; set; }

        [BindProperty]
        public FullCustomerDTO EditThisCustomer { get; set; }

        public void OnGet()
        {
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

            AllDinosaurs = _dinoService.GetFullDinoList(Options).ToList();
        }
    }
}
