using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IWebHostEnvironment _webHost;
        private readonly IDinoAdminService _dinoService;
        private readonly ICustomerServiceAdmin _adminService;

        public IndexModel(IWebHostEnvironment webHost, IDinoAdminService dinoService, ICustomerServiceAdmin serviceAdmin)
        {
            _webHost = webHost;
            _dinoService = dinoService;
            _adminService = serviceAdmin;
        }

        public SortFilterPageOptions Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CurrentPage { get; set; }

        [Display(Name = "Side st�relse")]
        [BindProperty(SupportsGet = true)]
        public uint? PageSize { get; set; }

        [Display(Name = "Filtrer p� Diet")]
        [BindProperty(SupportsGet = true)]
        public int? FilterDiet { get; set; }

        [BindProperty]
        public int TotalPages { get; set; }

        [Display(Name = "Sorter efter")]
        [BindProperty(SupportsGet = true)]
        public int? OrderBy { get; set; }

        public IList<DinosaurDTO> AllDinosaurs { get; set; }

        [BindProperty]
        public DinosaurDTO AddNewDino { get; set; }

        public IList<FullCustomerDTO> AllCustomers { get; set; }

        [BindProperty]
        public int DeletedDinoId { get; set; }

        [BindProperty]
        public int DeletedCustomerId { get; set; }

        public SelectList PromotionsDDL { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }

        public void OnGet()
        {
            Options = new SortFilterPageOptions();

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

            PromotionsDDL = new SelectList(_dinoService.PromotionList().ToList(), "PromotionId", "PromotionName");

            AllDinosaurs = _dinoService.GetFullDinoList(Options).ToList();
            TotalPages = Options.PagesCount;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (DeletedDinoId > 0)
            {
                await _dinoService.DeleteDinoById(DeletedDinoId);
                return RedirectToPage("./Index");
            }

            if (AddNewDino != null)
            {
                string fileExtension = Picture.FileName.Split('.').Last().ToLower();
                if (fileExtension == "jpg" || fileExtension == "jpeg" || fileExtension == "png")
                {
                    string file = Path.Combine(_webHost.WebRootPath, "img", Picture.FileName);
                    using (FileStream fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Picture.CopyToAsync(fileStream);
                    }
                    AddNewDino.DinoPicture = "~/img/" + Picture.FileName;
                }
                
                await _dinoService.AddNewDino(AddNewDino);
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
