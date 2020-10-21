using ServiceLayer.CustomerService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.CustomerService.Services.Interfaces
{
    public interface ICustomerServiceAdmin
    {
        Task<int> AddNewCustomer(FullCustomerDTO newCustomer);
        Task<int> DeleteCustomerById(int id);
        IQueryable<FullCustomerDTO> GetAllCustomers();
        Task<FullCustomerDTO> GetCustomerByID(int id);
    }
}