using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.CustomerService.Services.Interfaces;
using ServiceLayer.CustomerService.DTOCollection;

namespace DinosaurShoppen.Pages.CustomerPages
{
    public class CreateCustomerModel : PageModel
    {
        private readonly ICustomerServiceAdmin _customerService;

        public CreateCustomerModel(ICustomerServiceAdmin customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FullCustomerDTO Customer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.AddNewCustomer(Customer);

            return RedirectToPage("./Login");
        }
    }
}
