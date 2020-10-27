using ServiceLayer.Rabat_PromotionService.DTOCollection;
using System.Threading.Tasks;

namespace ServiceLayer.Rabat_PromotionService.Services.Interfaces
{
    public interface IRabatService
    {
        Task<int> AddNewRabat(RabatDTO rabatDTO);
        Task<int> DeleteRabat(int rabatId);
        Task<int> UpdateRabat(RabatDTO rabatDto);
        RabatDTO GetRabatDTOById(int rabatId);
    }
}