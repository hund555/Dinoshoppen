using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHost;
        private readonly IDinoAdminService _dinoService;
        public EditDinoModel(IWebHostEnvironment webHost, IDinoAdminService dinoService)
        {
            _webHost = webHost;
            _dinoService = dinoService;
        }

        [BindProperty]
        public DinosaurDTO Dinosaur { get; set; }

        public SelectList PromotionsDDL { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? DinosaurId { get; set; }

        [DefaultValue(true)]
        [BindProperty]
        public bool KeepPicture { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }

        public void OnGet()
        {
            Dinosaur = _dinoService.GetDinosaurDTOById((int)DinosaurId);
            PromotionsDDL = new SelectList(_dinoService.PromotionList().ToList(), "PromotionId", "PromotionName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Picture != null)
            {
                string fileExtension = Picture.FileName.Split('.').Last().ToLower();
                if (fileExtension == "jpg" || fileExtension == "jpeg" || fileExtension == "png")
                {
                    string file = Path.Combine(_webHost.WebRootPath, "img", Dinosaur.DinosaurId + "." + fileExtension);
                    using (FileStream fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Picture.CopyToAsync(fileStream);
                    }
                    Dinosaur.DinoPicture = fileExtension;
                }
            }
            else if (KeepPicture == false && !string.IsNullOrEmpty(Dinosaur.DinoPicture))
            {
                string file = Path.Combine(_webHost.WebRootPath, "img", Dinosaur.DinosaurId + "." + Dinosaur.DinoPicture);

                System.IO.File.Delete(file);
                Dinosaur.DinoPicture = null;
            }

            await _dinoService.UpdateDinosaur(Dinosaur);

            return RedirectToPage("./Index");
        }
    }
}
