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
    public class UserController : MainController
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpGet("get/{userId:int}")]
        public async Task<IActionResult> GetAsync(int userId)
            => CustomResponse(await _userApplicationService.GetAsync(userId));

        [HttpGet("get-byusername/{userName:alpha}")]
        public async Task<IActionResult> GetByUserNameAsync(string userName)
            => CustomResponse(await _userApplicationService.GetByUserNameAsync(userName));


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PageFilter filter)
            => CustomResponsePaged(await _userApplicationService.GetAllAsync(filter));

        [HttpPost("insert")]
        public async Task<IActionResult> Add([FromBody] UserProfileViewModel userProfile)
        {
            var pageResult = new PageResult<UserProfileViewModel>(userProfile);
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _userApplicationService.Insert(userProfile);
            return CustomResponse(pageResult);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserProfileViewModel userProfile)
        {
            var pageResult = new PageResult<UserProfileViewModel>(userProfile);
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _userApplicationService.Update(userProfile);
            return CustomResponse(pageResult);
        }


        [HttpDelete("delete/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var pageResult = new PageResult<UserProfileViewModel>();
            if (!ModelState.IsValid) return CustomResponse(pageResult);
            pageResult = await _userApplicationService.Delete(userId);
            return CustomResponse(pageResult);
        }


    }
}

