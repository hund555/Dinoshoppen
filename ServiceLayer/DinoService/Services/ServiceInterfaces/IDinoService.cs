using ServiceLayer.DinoService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services.ServiceInterfaces
{
    public interface IDinoService
    {
        Task<int> AddDinoToCart(int customerId, int dinoId, int antal);
        DinosaurDTO GetDinoById(int dinoId);
        IQueryable<ListDinoDTO> GetFullDinoList(SortFilterPageOptions options);
        IQueryable<ListDinoDTO> GetDinoListWithNameFilter(SortFilterPageOptions options, string dinoName);
        IQueryable<ListDinoDTO> GetTop6PromotionDino();
    }
}