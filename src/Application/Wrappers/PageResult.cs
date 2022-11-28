using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Wrappers
{
    public class PageResult<T>
    {

        public T Data { get; set; }

        public IEnumerable<ModelError> Errors { get; set; }

        public PageResult()
        {
            Errors = Enumerable.Empty<ModelError>();
        }

        public PageResult(T data) : this()
        {
            Data = data;
        }

    }
}
