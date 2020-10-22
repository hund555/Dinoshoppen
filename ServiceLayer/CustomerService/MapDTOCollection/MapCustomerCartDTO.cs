using DataLayer.Entities;
using ServiceLayer.CustomerService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomerService.MapDTOCollection
{
    public static class MapCustomerCartDTO
    {
        public static IQueryable<CustomerCartDTO> MapCustomerCartToDTO(this IQueryable<Customer> customer)
        {
            return customer.Select(c => new CustomerCartDTO
            {
                CustomerId = c.CustomerId,
                
            });
        }
    }
}
