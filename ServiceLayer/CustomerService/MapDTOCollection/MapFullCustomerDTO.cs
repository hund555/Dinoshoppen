using DataLayer.Entities;
using ServiceLayer.CustomerService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomerService.MapDTOCollection
{
    public static class MapFullCustomerDTO
    {
        public static IQueryable<FullCustomerDTO> MapFullCustomerToDTO(this IQueryable<Customer> customers)
        {
            return customers.Select(c => new FullCustomerDTO
            {
                CustomerId = c.CustomerId,
                Address = c.Address,
                Mail = c.Mail,
                Name = c.Name,
                Card = c.Carts
            });
        }
    }
}
