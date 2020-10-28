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
using ServiceLayer.Rabat_PromotionService.DTOCollection;
using ServiceLayer.Rabat_PromotionService.Services.Interfaces;

namespace DinosaurShoppen.Pages.Administration
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IDinoAdminService _dinoService;
        private readonly ICustomerServiceAdmin _adminService;
        private readonly IRabatService _rabatService;
        private readonly IPromotionService _promotionService;

        public IndexModel(IWebHostEnvironment webHost, IDinoAdminService dinoService, ICustomerServiceAdmin serviceAdmin, IRabatService rabatService, IPromotionService promotionService)
        {
            _webHost = webHost;
            _dinoService = dinoService;
            _adminService = serviceAdmin;
            _rabatService = rabatService;
            _promotionService = promotionService;
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
        public DinosaurDTO AddNewDino { get; set; }

        public IList<RabatDTO> Rabats { get; set; }

        [BindProperty]
        public int DeletedRabatId { get; set; }

        public IList<PromotionDTO> Promotions { get; set; }

        [BindProperty]
        public int DeletedPromotionId { get; set; }

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
            Rabats = _rabatService.GetAllRabats().ToList();
            Promotions = _promotionService.GetAllPromotions().ToList();
            TotalPages = Options.PagesCount;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (DeletedDinoId > 0)
            {
                DinosaurDTO dino = _dinoService.GetDinosaurDTOById(DeletedDinoId);

                await _dinoService.DeleteDinoById(DeletedDinoId);

                if (dino != null && !string.IsNullOrEmpty(dino.DinoPicture))
                {
                    string file = Path.Combine(_webHost.WebRootPath, "img", dino.DinosaurId + "." + dino.DinoPicture);

                    System.IO.File.Delete(file);
                }
                
                return RedirectToPage("./Index");
            }

            if (DeletedRabatId > 0)
            {
                await _rabatService.DeleteRabat(DeletedRabatId);
                return RedirectToPage("./Index");
            }

            if (DeletedPromotionId > 0)
            {
                await _promotionService.DeletePromotion(DeletedPromotionId);
                return RedirectToPage("./Index");
            }

            if (AddNewDino != null)
            {
                string fileExtension = Picture.FileName.Split('.').Last().ToLower();
                
                if (fileExtension == "jpg" || fileExtension == "jpeg" || fileExtension == "png")
                {
                    AddNewDino.DinoPicture = fileExtension;

                    int dinoId = await _dinoService.AddNewDino(AddNewDino);

                    string file = Path.Combine(_webHost.WebRootPath, "img", dinoId + "." + fileExtension);
                    using (FileStream fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Picture.CopyToAsync(fileStream);
                    }
                }

                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
