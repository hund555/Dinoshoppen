using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Rabat_PromotionService.DTOCollection;
using ServiceLayer.Rabat_PromotionService.MapDTOCollection;
using ServiceLayer.Rabat_PromotionService.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Rabat_PromotionService.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly DinoDbContext _context;
        public PromotionService(DinoDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewPromotion(PromotionDTO promotionDTO)
        {
            Promotion promotion = new Promotion()
            {
                PromotionName = promotionDTO.PromotionName,
                PromotionRabat = promotionDTO.PromotionRabat
            };

            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<int> UpdatePromotion(PromotionDTO promotionDto)
        {
            _context.Promotions.Update(promotionDto.MapDTOToPromotion());

            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<int> DeletePromotion(int promotionId)
        {
            Promotion promotion = await _context.Promotions
                .FindAsync(promotionId);

            _context.Promotions.Remove(promotion);

            await _context.SaveChangesAsync();

            return 0;
        }

        public PromotionDTO GetPromotionDTOById(int promotionId)
        {
            return _context.Promotions
                .MapPromotionToDTO()
                .FirstOrDefault(p => p.PromotionId == promotionId);
        }

        public IQueryable<PromotionDTO> GetAllPromotions()
        {
            return _context.Promotions
                .MapPromotionToDTO()
                .AsNoTracking();
        }
    }
}
