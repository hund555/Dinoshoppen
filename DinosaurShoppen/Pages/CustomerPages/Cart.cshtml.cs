using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CustomerService.Services.Interfaces;
using System.Threading.Tasks;

namespace DinosaurShoppen.Pages.CustomerPages
{
    public class CartModel : PageModel
    {
        private readonly ICustomerServiceUsers _customerService;

        public CartModel(ICustomerServiceUsers customerService)
        {
            _customerService = customerService;
        }

        public DataLayer.Entities.Customer Customer { get; set; }

        public double TotalPrice { get; set; }

        [BindProperty]
        public int CustomerId { get; set; }

        [BindProperty]
        public string CustomerEmail { get; set; }

        [BindProperty]
        public string RabatNavn { get; set; }

        [BindProperty]
        public uint AntalRemovedDinoCount { get; set; }

        [BindProperty]
        public int RemovedDinoId { get; set; }

        [TempData]
        public string Message { get; set; }

        public string EmptyCart { get; set; }

        public void OnGet()
        {
            int? myId = HttpContext.Session.GetInt32("_customerId");

            if (myId == null || myId == 0)
            {
                RedirectToPage("/Customer/Login");
            }

            Customer = _customerService.GetCustomerCartById((int)myId);
            TotalPrice = 0;
            foreach (var item in Customer.Carts)
            {
                TotalPrice += (item.Dinosaur.DinoPrice - (item.Dinosaur.DinoPrice / 100 * item.Dinosaur.Promotion.PromotionRabat)) * item.Amound;
                if (item.RabatId != null)
                {
                    TotalPrice -= TotalPrice / 100 * item.Rabat.RabatProcent;
                }
            }

            if (TotalPrice <= 0)
            {
                EmptyCart = "Du har ikke noget i din kurv";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (AntalRemovedDinoCount > 0 && RemovedDinoId > 0 && CustomerId > 0)
            {
                await _customerService.RemoveItemsFromCart(CustomerId, RemovedDinoId, (int)AntalRemovedDinoCount);
                return RedirectToPage("./Cart");
            }

            if (!string.IsNullOrEmpty(RabatNavn) && CustomerId > 0)
            {
                int result = await _customerService.AddRabatToCart(RabatNavn, CustomerId);
                if (result == 1)
                {
                    Message = "Kunne ikke genkende rabatkoden";
                }
                return RedirectToPage("./Cart");
            }

            if (CustomerId > 0 && !string.IsNullOrEmpty(CustomerEmail))
            {
                //send mail kommer
                return RedirectToPage("/DinoList/Index");
            }

            return RedirectToPage("/Error");
        }
    }
}
