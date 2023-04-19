using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private ILogger<AuthController> _logger;
        
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
           
            
            _logger = logger;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                _logger.LogInformation(1,"{0} is not login at {1}",userForLoginDto.Email,DateTime.Now);
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                _logger.LogInformation("{0} is login at {1}", userForLoginDto.Email, DateTime.Now);
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                _logger.LogInformation("{0} is not register at {1}", userForRegisterDto.Email, DateTime.Now);
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                _logger.LogInformation("{0} is register at {1}", userForRegisterDto.Email, DateTime.Now);
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlog")]
        public ActionResult GetLog()
        {
            var result= _logger.ToString();
            return Ok(result);
        }
    }
}
