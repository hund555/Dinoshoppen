using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CustomerService.DTOCollection;
using ServiceLayer.CustomerService.MapDTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CustomerService.Services
{
    public class CustomerServiceAdmin
    {
        private readonly DinoDbContext _context;
        public CustomerServiceAdmin(DinoDbContext context)
        {
            _context = context;
        }

        public IQueryable<FullCustomerDTO> GetAllCustomers()
        {
            return _context.Customers
                .AsNoTracking()
                .MapFullCustomerToDTO();
        }

        public async Task<FullCustomerDTO> GetCustomerByID(int id)
        {
            Customer customer = await _context.Customers
                .AsNoTracking()
                .Include(c => c.Carts)
                .ThenInclude(d => d.Dinosaur)
                .SingleOrDefaultAsync(c => c.CustomerId == id);

            return new FullCustomerDTO
            {
                CustomerId = customer.CustomerId,
                Address = customer.Address,
                Mail = customer.Mail,
                Name = customer.Name
            };
        }

        public async Task<int> DeleteCustomerById(int id)
        {
            Customer customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<int> AddNewCustomer(FullCustomerDTO newCustomer)
        {
            Customer customer = new Customer
            {
                Name = newCustomer.Name,
                Address = newCustomer.Address,
                Mail = newCustomer.Mail
            };

            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();

            return 0;
        }
    }
}
