using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DocumentStorage.Api.Controller
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {

        protected ActionResult CustomResponsePaged<T>(PagedResult<T> pagedResult = null)
        {
            //var pagedResult = result as PagedResult<T>;

            if (pagedResult.Errors.Count() == 0)
            {
                return Ok(new
                {
                    success = true,
                    pageIndex = pagedResult.PageIndex,
                    pageSize = pagedResult.PageSize,
                    totalResults = pagedResult.TotalResults,
                    totalPages = pagedResult.TotalPages,
                    data = pagedResult.Data,
                    errors = pagedResult.Errors
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = pagedResult.Errors
            });
        }

        protected ActionResult CustomResponse<T>(PageResult<T>? pageResult = null)
        {
            var modelErrors = GetModelStateErrors();
            foreach (var error in modelErrors)
                pageResult.Errors = pageResult.Errors.Append(error);

            if (pageResult.Errors.Count() == 0)
            {
                return Ok(new
                {
                    success = true,
                    data = pageResult.Data,
                    errors = pageResult.Errors
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = pageResult.Errors
            });
        }

        private IEnumerable<ModelError> GetModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(e => e.Errors);
            return errors;
        }


    }
}
