using System;
using System.Linq;

namespace DataLayer.QueryObjects
{
    public static class GenericPaging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
        {
            if (pageSize <= 0)
            {
                pageSize = 12;
            }
            if (pageSize != 0)
            {
                query = query.Skip(pageNumZeroStart * pageSize);
            }
            return query.Take(pageSize);
        }
    }
}
