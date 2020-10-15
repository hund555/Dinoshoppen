﻿using ServiceLayer.DinoService.DTOCollection;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.DinoService.Services.ServiceInterfaces
{
    public interface IDinoService
    {
        Task<DinosaurDTO> AddNewDino(DinosaurDTO newDino);
        Task<int> DeleteDinoById(int id);
        IQueryable<ListDinoDTO> GetFullDinoList(SortFilterPageOptions options);
        IQueryable<ListDinoDTO> GetTop6PromotionDino();
    }
}