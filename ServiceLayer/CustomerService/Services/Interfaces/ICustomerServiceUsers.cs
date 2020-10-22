using ServiceLayer.CustomerService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.CustomerService.Services.Interfaces
{
    public interface ICustomerServiceUsers
    {
        FullCustomerDTO GetCustomerByEmail(string email, string password);
        IQueryable<CustomerCartDTO> GetCustomerCartById(int customerId);
        int GetCustomerCartItemsCount(int customerId);
        Task<int> RemoveItemsFromCart(int customerId, int dinoId, int antal);
    }
}