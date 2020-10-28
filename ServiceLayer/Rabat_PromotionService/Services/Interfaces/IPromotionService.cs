using ServiceLayer.Rabat_PromotionService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Rabat_PromotionService.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<int> AddNewPromotion(PromotionDTO promotionDTO);
        Task<int> DeletePromotion(int promotionId);
        IQueryable<PromotionDTO> GetAllPromotions();
        PromotionDTO GetPromotionDTOById(int promotionId);
        Task<int> UpdatePromotion(PromotionDTO promotionDto);
    }
}