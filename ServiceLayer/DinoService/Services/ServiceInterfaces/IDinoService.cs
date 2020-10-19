using ServiceLayer.DinoService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services.ServiceInterfaces
{
    public interface IDinoService
    {
        Task<DinosaurDTO> AddNewDino(DinosaurDTO newDino);
        Task<int> AddDinoToCart(int customerId, int dinoId, int antal);
        DinosaurDTO GetDinoById(int dinoId);
        Task<int> DeleteDinoById(int id);
        IQueryable<ListDinoDTO> GetFullDinoList(SortFilterPageOptions options);
        IQueryable<ListDinoDTO> GetDinoListWithNameFilter(SortFilterPageOptions options, string dinoName);
        IQueryable<ListDinoDTO> GetTop6PromotionDino();
    }
}