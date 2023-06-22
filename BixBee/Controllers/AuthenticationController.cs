using BixBee.Domain.Interface.IAuthentication;
using BixBee.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BixBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public AuthenticationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register(RegistrationModel user)
        {
            var UserAccess = await _registrationService.Registration(user);
            return Ok(UserAccess);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]LoginModel user)
        {
            var UserAccess = await _registrationService.Login(user);
            return Ok(UserAccess);
        }

    }
}
