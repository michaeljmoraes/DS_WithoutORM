using Api.Controller;
using Application.Services;
using Application.Wrappers;
using Domain.CoreModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DocumentController : MainController
    {
        private readonly IDocumentApplicationService _applicationService;

        public DocumentController(IDocumentApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
            => CustomResponse(await _applicationService.GetAsync(id));


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PageFilter filter)
            => CustomResponsePaged(await _applicationService.GetAllAsync(filter));

        [HttpPost("insert")]
        public async Task<IActionResult> Add([FromBody] DocumentViewModel viewModel)
        {
            var pageResult = new PageResult<DocumentViewModel>(viewModel);
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _applicationService.Insert(viewModel);
            return CustomResponse(pageResult);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] DocumentViewModel viewModel)
        {
            var pageResult = new PageResult<DocumentViewModel>(viewModel);
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _applicationService.Update(viewModel);
            return CustomResponse(pageResult);
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pageResult = new PageResult<DocumentViewModel>();
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _applicationService.Delete(id);
            return CustomResponse(pageResult);
        }


    }
}

