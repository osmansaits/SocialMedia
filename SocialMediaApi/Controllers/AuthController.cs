using Business.Abstracts;
using Dto.Request;
using Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Utilities;




namespace SocialMediaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService, IConfiguration configuration, IJwtService jwtService)
        {
            _authService = authService;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthAddRequestDto dto)
        {
            var result = _authService.Login(dto);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return Unauthorized(Messages.userNotFound);
        }
       

        [HttpPost("add")]
        public void Add([FromBody] AuthAddRequestDto dto)
        {
            _authService.Add(dto);
        }

        [HttpGet("getAll")]
        public List<AuthResponseDto> GetAll() => _authService.GetAll();


        [HttpPost("delete")]
        public void Delete([FromBody] AuthDeleteRequestDto dto) => _authService.Delete(dto);


    }
}
