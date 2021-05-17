using CoreApi.Services.Infrastructure;
using CoreApi.Utils;
using CoreAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        private ILoginService _loginService;

        [HttpPost]
        public TResponse Login(LoginDto loginDto)
        {
            return _loginService.Login(loginDto);
        }
    }
}
