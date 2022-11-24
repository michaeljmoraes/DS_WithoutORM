using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DocumentStorage.Api.Controller;
using DocumentStorage.HomePage;
using DocumentStorage.HomePage.Application.Services;
using DocumentStorage.HomePage.Application.ViewModels;

namespace DocumentStorage.Api.V1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostController : MainController
    {
        private readonly IPostAppService _postAppService;
        private readonly IMapper _mapper;

        public PostController(IMapper mapper, IPostAppService postAppService)
        {
            _mapper = mapper;
            _postAppService = postAppService;
        }


        [HttpGet]
        public async Task<IEnumerable<PostViewModel>> GetPosts()
            => _mapper.Map<IEnumerable<PostViewModel>>(await _postAppService.GetPosts());

        [HttpGet("get-following-posts/{userId:guid}")]
        public async Task<IEnumerable<PostViewModel>> GetFollowingPosts(Guid userId)
            => _mapper.Map<IEnumerable<PostViewModel>>(await _postAppService.GetFollowingPosts(userId));


        [HttpPost("add-post")]
        public async Task<ActionResult<PostViewModel>> AddPost([FromBody]PostViewModel postViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(postViewModel);

            await _postAppService.Add(postViewModel);

            return Ok(postViewModel);
            
        }
        
    }
}
