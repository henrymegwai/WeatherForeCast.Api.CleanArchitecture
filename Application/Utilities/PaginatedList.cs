using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public List<T>? Items { get; private set; } 
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int totalCount = await source.CountAsync();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new(){ Items = items, TotalCount = totalCount, PageIndex = pageIndex, PageSize = pageSize };
        }
    }
}