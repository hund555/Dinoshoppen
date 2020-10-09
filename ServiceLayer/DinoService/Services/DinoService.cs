using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.MapDTOCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services
{
    public class DinoService
    {
        private readonly DinoDbContext _context;

        public DinoService(DinoDbContext dinoDbContext)
        {
            _context = dinoDbContext;
        }

        public IQueryable GetTop6PromotionDino()
        {
            return _context.Dinosaurs
                .Where(p => p.PromotionId != null)
                .OrderByDescending(p => p.DinoPrice)
                .AsNoTracking()
                .Take(6)
                .MapToDinoList();
        }

        public async Task<DinosaurDTO> AddNewDino(DinosaurDTO newDino)
        {
            Dinosaur dino = new Dinosaur()
            {
                DinoName = newDino.DinoName,
                DinoWeight = newDino.DinoWeight,
                DinoLenght = newDino.DinoLenght,
                DinoHeight = newDino.DinoHeight,
                DinoPrice = newDino.DinoPrice,
                DietId = newDino.DietId,
                PromotionId = newDino.PromotionId
            };

            _context.Dinosaurs.Add(dino);
            await _context.SaveChangesAsync();

            return newDino;
        }
    }
}
