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
using System.Threading.Tasks;

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

        public IQueryable<CustomerCartDTO> GetCustomerCartById(int customerId)
        {
            return _context.Customers
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Carts)
                    .ThenInclude(r => r.Rabat)
                .Include(c => c.Carts)
                    .ThenInclude(d => d.Dinosaur)
                    .ThenInclude(d => d.Diet)
                .Include(c => c.Carts)
                    .ThenInclude(d => d.Dinosaur)
                    .ThenInclude(d => d.Promotion)
                .MapCustomerCartToDTO();
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

        public async Task<int> RemoveItemsFromCart(int customerId, int dinoId, int antal)
        {
            Customer customer = await _context.Customers
                .Include(c => c.Carts)
                .SingleOrDefaultAsync(c => c.CustomerId == customerId);

            foreach (Cart item in customer.Carts)
            {
                if (item.DinosaurId == dinoId)
                {
                    item.Amound -= antal;
                    if (item.Amound < 0)
                    {
                        customer.Carts.Remove(item);
                    }
                    await _context.SaveChangesAsync();
                    return 0;
                }
            }
            
            return 1;
        }
    }
}
