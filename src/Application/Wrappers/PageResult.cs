using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PageResult<T>
    {

        public T Data { get; set; }

        public IEnumerable<ModelError> Errors { get; set; }

        public PageResult() {
            Errors = Enumerable.Empty<ModelError>();
        }

        public PageResult(T data) : this()
        {
             Data = data;
        }

    }
}
