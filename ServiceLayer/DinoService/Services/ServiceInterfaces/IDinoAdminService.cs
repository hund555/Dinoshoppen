using ServiceLayer.DinoService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services.ServiceInterfaces
{
    public interface IDinoAdminService
    {
        Task<DinosaurDTO> AddNewDino(DinosaurDTO newDino);
        Task<int> DeleteDinoById(int id);
        IQueryable<DinosaurDTO> GetFullDinoList(SortFilterPageOptions options);
        IQueryable<PromotionListDTO> PromotionList();
        DinosaurDTO GetDinosaurDTOById(int dinoId);
    }
}