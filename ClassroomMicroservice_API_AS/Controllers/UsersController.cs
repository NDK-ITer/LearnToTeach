using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDemoAPIAsp.NETCore.Models;
using MyDemoAPIAsp.NETCore.Repositories.AccountRepository.InterfaceRepositories;

namespace MyDemoAPIAsp.NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountRepository userRepository;

        public UsersController(IAccountRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var result = await userRepository.Register(registerModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await userRepository.Login(loginModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
