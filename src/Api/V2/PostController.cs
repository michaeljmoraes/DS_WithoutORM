//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DocumentStorage.Api.Controller;
//using DocumentStorage.Application.Services;
//using DocumentStorage.Application.ViewModels;
//using DocumentStorage.Application.Wrappers;
//using DocumentStorage.Domain.Models;

namespace DocumentStorage.Api.V2.Controllers
{

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostController : MainController
    {
        //private readonly IPostApplicationService _postApplicationService;
        //private readonly IMapper _mapper;

        //public PostController(IMapper mapper, IPostApplicationService postApplicationService)
        //{
        //    _mapper = mapper;
        //    _postApplicationService = postApplicationService;
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetPosts([FromQuery]PageFilter filter)
        //    => CustomResponsePaged(await _postApplicationService.GetPosts(filter));

        //[HttpGet("get-user-posts/{userId:guid}")]
        //public async Task<IActionResult> GetPostsByUser(Guid userId, [FromQuery]PageFilter filter)
        //    => CustomResponsePaged(await _postApplicationService.GetByUser(userId, filter));

        //[HttpGet("get-following-posts/{userId:guid}")]
        //public async Task<IActionResult> GetFollowingPosts(Guid userId, [FromQuery]PageFilter filter)
        //    => CustomResponsePaged(await _postApplicationService.GetFollowingPosts(userId, filter));

        //[HttpPost("add-post")]
        //public async Task<IActionResult> AddPost([FromBody]PostViewModel postViewModel)
        //{
        //    var pageResult = new PageResult<PostViewModel>(postViewModel);

        //    if (!ModelState.IsValid) return CustomResponse(pageResult);

        //    pageResult = await _postApplicationService.Add(postViewModel);

        //    return CustomResponse(pageResult);
            
        //}
        
    }
}
