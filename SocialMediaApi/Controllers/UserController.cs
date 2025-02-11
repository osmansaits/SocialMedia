using Business.Abstracts;
using Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost("Add")]
        public void Add([FromBody] UserAddRequestDto dto)
        {
            _userService.Add(dto);
        }
        [HttpPost("Delete")]
        public void Delete([FromBody] UserDeleteRequestDto dto)
        {
            _userService.Delete(dto);

        }
    }
}
