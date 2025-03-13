using Business.Abstracts;
using Dto.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost("add")]
       public void Add(PostAddRequestDto dto) 
        {
            _postService.Add(dto);
        }
    }
}
