//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
using DocumentStorage.Api.Controller;
using Application.Services;
using Domain.CoreModels;
using Domain.Models;
using Application.Wrappers;
//using DocumentStorage.Application.Services;
//using DocumentStorage.Application.ViewModels;
//using DocumentStorage.Application.Wrappers;
//using System.Collections.Generic;

namespace DocumentStorage.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GroupController : MainController
    {
        private readonly IGroupApplicationService _groupApplicationService;

        public GroupController(IGroupApplicationService groupApplicationService)
        {
            _groupApplicationService = groupApplicationService;
        }

        [HttpGet("get/{userId:int}")]
        public async Task<IActionResult> GetAsync(int userId)
            => CustomResponse(await _groupApplicationService.GetAsync(userId));


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PageFilter filter)
            => CustomResponsePaged(await _groupApplicationService.GetAllAsync(filter));

        [HttpPost("insert")]
        public async Task<IActionResult> Add([FromBody] GroupViewModel group)
        {
            var pageResult = new PageResult<GroupViewModel>(group);
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _groupApplicationService.Insert(group);
            return CustomResponse(pageResult);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] GroupViewModel groupProfile)
        {
            var pageResult = new PageResult<GroupViewModel>(groupProfile);
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _groupApplicationService.Update(groupProfile);
            return CustomResponse(pageResult);
        }


        [HttpDelete("delete/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var pageResult = new PageResult<GroupViewModel>();
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _groupApplicationService.Delete(userId);
            return CustomResponse(pageResult);
        }


    }
}

