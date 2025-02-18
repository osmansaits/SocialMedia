using Business.Abstracts;
using Dto.Request;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


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
        
        [HttpPost("add")]
        public void Add([FromBody] UserAddRequestDto dto)
        {
            _userService.Add(dto);
        }
        
        [HttpGet("getAll")]
        public List<User> GetAll() => _userService.GetAll();

        
        [HttpPost("delete")]
        public void Delete([FromBody] UserDeleteRequestDto dto) => _userService.Delete(dto);

        
    }
}
