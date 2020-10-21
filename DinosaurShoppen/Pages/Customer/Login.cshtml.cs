using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CustomerService.DTOCollection;
using ServiceLayer.CustomerService.Services.Interfaces;

namespace DinosaurShoppen.Pages.Customer
{
    public class LoginModel : PageModel
    {
        public const string SessionKeyEmail = "_email";
        public const string SessionKeycustomerId = "_customerId";
        public const string SessionKeyName = "_name";

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            HttpContext.Session.SetString(SessionKeyEmail, "");
            HttpContext.Session.SetInt32(SessionKeycustomerId, 0);
            HttpContext.Session.SetString(SessionKeyName, "");
        }
    

        public IActionResult OnPost([FromServices] ICustomerServiceUsers _customerService)
        {
            FullCustomerDTO customer = _customerService.GetCustomerByEmail(Email, Password);
            if (customer != null)
            {
                HttpContext.Session.SetString(SessionKeyEmail, customer.Mail);
                HttpContext.Session.SetInt32(SessionKeycustomerId, customer.CustomerId);
                HttpContext.Session.SetString(SessionKeyName, customer.Name);
            }
            return RedirectToPage("/DinoList/Index");
        }
    }
}
