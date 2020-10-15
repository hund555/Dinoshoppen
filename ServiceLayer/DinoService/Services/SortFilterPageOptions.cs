using ServiceLayer.DinoService.EnumCollection;
using System;
using System.Linq;

namespace ServiceLayer.DinoService.Services
{
    public class SortFilterPageOptions
    {
        public EnumDinoFilter FilterByDiet { get; set; }

        public EnumOrderDinoListByOptions OrderByOptions { get; set; }


        public const int DefaultPageSize = 10;

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int PagesCount { get; set; }

        public void SetUpRestOfDto<T>(IQueryable<T> query)
        {
            PagesCount = (int)Math.Ceiling((double)query.Count() / PageSize);
            PageNumber = Math.Min(Math.Max(1, PageNumber), PagesCount);
        }
    }
}
