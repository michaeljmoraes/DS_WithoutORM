using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DocumentStorage.Api.Controller;
using DocumentStorage.HomePage;
using DocumentStorage.HomePage.Application.Services;
using DocumentStorage.HomePage.Application.ViewModels;
using DocumentStorage.HomePage.Domain;
using DocumentStorage.HomePage.Domain.Models;
using System.Collections.Generic;

namespace DocumentStorage.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserProfileController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IUserAppService _userAppService;

        public UserProfileController(IMapper mapper, 
            IUserAppService userAppService)
        {
            _mapper = mapper;
            _userAppService = userAppService;
        }

        [HttpGet("users")]
        public async Task<PageResult<IEnumerable<UserViewModel>>> GetAllAsync()
            => await _userAppService.GetAllAsync();

        [HttpGet("{userId:guid}")]
        public async Task<PageResult<UserProfileViewModel>> GetUserProfileAsync(Guid userId)
            => await _userAppService.GetUserProfileAsync(userId);

        [HttpPost("follow")]
        public async Task<ActionResult<RelationshipViewModel>> FollowAsync([FromBody]RelationshipViewModel relationShip)
        {
            var result = await _userAppService.FollowAsync(relationShip);
            if (!result) return BadRequest(relationShip);
            return Ok(relationShip);
        }

        [HttpPost("unfollow")]
        public async Task<ActionResult<RelationshipViewModel>> UnFollowAsync([FromBody]RelationshipViewModel relationShip)
        {
            var result = await _userAppService.UnFollowAsync(relationShip);
            if (!result) return BadRequest(relationShip);
            return Ok(relationShip);
        }


    }
}

