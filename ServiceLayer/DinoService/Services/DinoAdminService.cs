using DataLayer;
using DataLayer.Entities;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.MapDTOCollection;
using ServiceLayer.DinoService.Services.ServiceInterfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services
{
    public class DinoAdminService : IDinoAdminService
    {
        private readonly DinoDbContext _context;

        public DinoAdminService(DinoDbContext context)
        {
            _context = context;
        }

        public IQueryable<DinosaurDTO> GetFullDinoList(SortFilterPageOptions options)
        {
            var dinoList = _context.Dinosaurs
                .AsNoTracking()
                .MapDinoToDto();

            options.SetUpRestOfDto(dinoList);
            return dinoList.Page(options.PageNumber - 1, options.PageSize);
        }

        public async Task<int> AddNewDino(DinosaurDTO newDino)
        {
            Dinosaur dino = new Dinosaur()
            {
                DinoName = newDino.DinoName,
                DinoWeight = newDino.DinoWeight,
                DinoLenght = newDino.DinoLenght,
                DinoHeight = newDino.DinoHeight,
                DinoPrice = newDino.DinoPrice,
                DietId = newDino.DietId,
                PromotionId = newDino.PromotionId,
                DinoPicture = newDino.DinoPicture
            };

            _context.Dinosaurs.Add(dino);
            await _context.SaveChangesAsync();

            return dino.DinosaurId;
        }

        public DinosaurDTO GetDinosaurDTOById(int dinoId)
        {
            return _context.Dinosaurs
                .MapDinoToDto()
                .FirstOrDefault(d => d.DinosaurId == dinoId);
        }

        public async Task<int> DeleteDinoById(int id)
        {
            Dinosaur dino = await _context.Dinosaurs.SingleOrDefaultAsync(d => d.DinosaurId == id);

            if (dino != null)
            {
                _context.Dinosaurs.Remove(dino);
            }

            await _context.SaveChangesAsync();

            return 0;
        }

        public IQueryable<PromotionListDTO> PromotionList()
        {
            return _context.Promotions
                .AsNoTracking()
                .MapPromotionListToDTO();
        }

        public async Task<int> UpdateDinosaur(DinosaurDTO updatedDino)
        {
            //var dino = _context.Dinosaurs.SingleOrDefaultAsync(d => d.DinosaurId == updatedDino.DinosaurId);

            _context.Dinosaurs.Update(updatedDino.MapDtoToDinosaur());

            await _context.SaveChangesAsync();

            return 0;
        }
    }
}
