using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CustomerService.DTOCollection;
using ServiceLayer.CustomerService.Services.Interfaces;

namespace DinosaurShoppen.Pages.Customer
{
    public class CartModel : PageModel
    {
        private readonly ICustomerServiceUsers _customerService;

        public CartModel(ICustomerServiceUsers customerService)
        {
            _customerService = customerService;
        }

        public FullCustomerDTO Customer { get; set; }

        [BindProperty]
        public int AntalRemovedDinoCount { get; set; }

        [BindProperty]
        public int RemovedDinoId { get; set; }
        public void OnGet()
        {
            int? myId = HttpContext.Session.GetInt32("_customerId");

            if (myId == null || myId == 0)
            {
                RedirectToPage("/Customer/Login");
            }


        }
    }
}
