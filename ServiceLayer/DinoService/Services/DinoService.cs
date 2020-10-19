using DataLayer;
using DataLayer.Entities;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.MapDTOCollection;
using ServiceLayer.DinoService.QueryObjects;
using ServiceLayer.DinoService.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services
{
    public class DinoService : IDinoService
    {
        private readonly DinoDbContext _context;

        public DinoService(DinoDbContext dinoDbContext)
        {
            _context = dinoDbContext;
        }

        public IQueryable<ListDinoDTO> GetTop6PromotionDino()
        {
            return _context.Dinosaurs
                .Where(p => p.PromotionId != null)
                .OrderByDescending(p => p.DinoPrice)
                .AsNoTracking()
                .Take(6)
                .MapToDinoList();
        }

        public IQueryable<ListDinoDTO> GetFullDinoList(SortFilterPageOptions options)
        {
            var dinoList = _context.Dinosaurs
                .AsNoTracking()
                .MapToDinoList()
                .OrderDinoListBy(options.OrderByOptions)
                .FilterListDinoBy(options.FilterByDiet);

            options.SetUpRestOfDto(dinoList);
            return dinoList.Page(options.PageNumber - 1, options.PageSize);
        }

        public IQueryable<ListDinoDTO> GetDinoListWithNameFilter(SortFilterPageOptions options, string dinoName)
        {
            var dinoList = _context.Dinosaurs
                .Where(d => d.DinoName.Contains(dinoName))
                .AsNoTracking()
                .MapToDinoList()
                .OrderDinoListBy(options.OrderByOptions)
                .FilterListDinoBy(options.FilterByDiet);

            options.SetUpRestOfDto(dinoList);
            return dinoList.Page(options.PageNumber - 1, options.PageSize);
        }

        public DinosaurDTO GetDinoById(int dinoId)
        {
            return _context.Dinosaurs
                .Where(d => d.DinosaurId == dinoId)
                .MapDinoToDto()
                .FirstOrDefault();
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

        public async Task<int> AddDinoToCart(int customerId, int dinoId, int antal)
        {
            Customer customerCart = await _context.Customers
                .Include(c => c.Carts)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            foreach (Cart item in customerCart.Carts)
            {
                if (item.DinosaurId == dinoId)
                {
                    item.Amound += antal;
                    return 0;
                }
            }

            Cart cart = new Cart() 
            {
                Amound = antal,
                CustomerId = customerId,
                DinosaurId = dinoId
            };

            _context.Add(cart);
            await _context.SaveChangesAsync();

            return 0;
        }
    }
}
