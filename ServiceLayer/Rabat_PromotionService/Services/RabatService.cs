using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ServiceLayer.Rabat_PromotionService.DTOCollection;
using ServiceLayer.Rabat_PromotionService.MapDTOCollection;
using ServiceLayer.Rabat_PromotionService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Rabat_PromotionService.Services
{
    public class RabatService : IRabatService
    {
        private readonly DinoDbContext _context;
        public RabatService(DinoDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewRabat(RabatDTO rabatDTO)
        {
            Rabat rabat = new Rabat()
            {
                RabatName = rabatDTO.RabatName,
                RabatProcent = rabatDTO.RabatProcent
            };

            _context.Rabats.Add(rabat);
            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<int> UpdateRabat(RabatDTO rabatDto)
        {
            _context.Rabats.Update(rabatDto.MapDTOToRabat());

            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<int> DeleteRabat(int rabatId)
        {
            Rabat rabat = await _context.Rabats
                .FindAsync(rabatId);

            _context.Rabats.Remove(rabat);

            await _context.SaveChangesAsync();

            return 0;
        }

        public RabatDTO GetRabatDTOById(int rabatId)
        {
            return _context.Rabats
                .MapRabatToDTO()
                .FirstOrDefault(r => r.RabatId == rabatId);
        }
    }
}
