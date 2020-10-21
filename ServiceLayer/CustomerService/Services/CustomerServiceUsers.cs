using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CustomerService.DTOCollection;
using ServiceLayer.CustomerService.MapDTOCollection;
using ServiceLayer.CustomerService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomerService.Services
{
    public class CustomerServiceUsers : ICustomerServiceUsers
    {
        private readonly DinoDbContext _context;
        public CustomerServiceUsers(DinoDbContext context)
        {
            _context = context;
        }

        public FullCustomerDTO GetCustomerByEmail(string email, string password)
        {
            return _context.Customers
                .AsNoTracking()
                .MapFullCustomerToDTO()
                .SingleOrDefault(c => c.Mail == email);
        }

        public FullCustomerDTO GetCustomerCartById(int customerId)
        {
            return _context.Customers
                .MapFullCustomerToDTO()
                .SingleOrDefault(c => c.CustomerId == customerId);
        }

        public int GetCustomerCartItemsCount(int customerId)
        {
            Customer customer = _context.Customers
                .AsNoTracking()
                .Include(c => c.Carts)
                .SingleOrDefault(c => c.CustomerId == customerId);

            int itemCount = 0;
            if (customer != null)
            {
                foreach (Cart item in customer.Carts)
                {
                    itemCount += item.Amound;
                }
            }
            return itemCount;
        }
    }
}
