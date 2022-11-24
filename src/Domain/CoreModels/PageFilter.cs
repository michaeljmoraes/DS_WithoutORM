using Core.DomainObjects;

namespace Domain.CoreModels
{
    public class PageFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }


        public PageFilter()
        {
            PageIndex = 1;
            PageSize = 5;
            Query = string.Empty;
        }

        public PageFilter(int pageIndex, int pageSize) : this()
        {
            PageIndex = pageIndex;
            PageSize = pageSize;

            Validate();
        }

        public PageFilter(int pageIndex, int pageSize, string query) : this(pageIndex, pageSize)
        {
            Query = query;
        }

        public void Validate()
        {
            Validations.ValidateHigherThan(PageSize, 10, "Exceeded maximum value for PageSize");
            Validations.ValidateLessThan(PageIndex, 1, "Invalid PageIndex, must be higher then 0");
        }

    }
}
