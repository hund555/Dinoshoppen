using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.CustomerService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaurShoppen.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICustomerServiceUsers _serviceUsers;
        public CartViewComponent(ICustomerServiceUsers serviceUsers)
        {
            _serviceUsers = serviceUsers;
        }

        public IViewComponentResult Invoke()
        {
            int? id = HttpContext.Session.GetInt32("_customerId");
            return View(_serviceUsers.GetCustomerCartItemsCount((int)id));
        }
    }
}
