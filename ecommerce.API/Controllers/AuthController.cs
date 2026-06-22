using eCommaerce.Core.DTO;
using eCommaerce.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            try
            {
                if (registerRequest == null)
                    return BadRequest("Invalide Register data");
                var result = await _userService.Register(registerRequest);

                if (result == null)
                {
                    return BadRequest("Data Not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                return BadRequest("Invalide login Data");
            var result = await _userService.Login(loginRequest);

            if (result == null)
            {
                return Unauthorized("Data not found");
            }
            return Ok(result);
        }
    }
}
