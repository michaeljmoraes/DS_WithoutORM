using Domain.CoreModels;

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
