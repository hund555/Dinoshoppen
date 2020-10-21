using DataLayer;
using DataLayer.Entities;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DinoService.DTOCollection;
using ServiceLayer.DinoService.MapDTOCollection;
using ServiceLayer.DinoService.QueryObjects;
using ServiceLayer.DinoService.Services.ServiceInterfaces;
using System.Linq;
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

        public async Task<int> AddDinoToCart(int customerId, int dinoId, int antal)
        {
            Customer customer = await _context.Customers
                .Include(c => c.Carts)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            foreach (Cart item in customer.Carts)
            {
                if (item.DinosaurId == dinoId)
                {
                    item.Amound += antal;
                    await _context.SaveChangesAsync();
                    return 0;
                }
            }
            Cart cart = new Cart() 
            {
                Amound = antal,
                CustomerId = customerId,
                DinosaurId = dinoId
            };

            customer.Carts.Add(cart);

            _context.Update(customer);
            await _context.SaveChangesAsync();

            return 0;
        }
    }
}
