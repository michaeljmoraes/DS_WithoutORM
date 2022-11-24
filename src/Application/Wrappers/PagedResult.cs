using Domain.CoreModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PagedResult<T> : PageResult<T>
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }

        public PagedResult(T data, int totalResults, PageFilter filter) : base(data)
        {
            PageIndex = filter.PageIndex;
            PageSize = filter.PageSize;
            TotalResults = totalResults;
            TotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(TotalResults) / Convert.ToDecimal(PageSize)));
        }

    }
}
