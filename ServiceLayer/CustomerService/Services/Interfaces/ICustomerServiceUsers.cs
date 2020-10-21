using ServiceLayer.CustomerService.DTOCollection;

namespace ServiceLayer.CustomerService.Services.Interfaces
{
    public interface ICustomerServiceUsers
    {
        FullCustomerDTO GetCustomerByEmail(string email, string password);
        FullCustomerDTO GetCustomerCartById(int customerId);
        int GetCustomerCartItemsCount(int customerId);
    }
}