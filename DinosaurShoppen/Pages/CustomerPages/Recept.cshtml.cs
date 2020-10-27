using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CustomerService.Services.Interfaces;

namespace DinosaurShoppen.Pages.CustomerPages
{
    public class ReceptModel : PageModel
    {
        private readonly ICustomerServiceUsers _customerService;

        public ReceptModel(ICustomerServiceUsers customerService)
        {
            _customerService = customerService;
        }

        public DataLayer.Entities.Customer Customer { get; set; }

        public double TotalPrice { get; set; }

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
                item.Dinosaur.DinoPrice = item.Dinosaur.DinoPrice - (item.Dinosaur.DinoPrice / 100 * item.Dinosaur.Promotion.PromotionRabat);
                TotalPrice += item.Dinosaur.DinoPrice * item.Amound;
                if (item.RabatId != null)
                {
                    TotalPrice -= TotalPrice / 100 * item.Rabat.RabatProcent;
                }
            }
        }
    }
}
