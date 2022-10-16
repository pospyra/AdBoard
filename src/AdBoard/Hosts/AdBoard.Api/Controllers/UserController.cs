using AdBoard.AppServices.User;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.Api.Controllers
{
    /// <summary>
    /// Работа с Пользователями
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]

    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;


        private UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(string login, string password, CancellationToken cancellation)
        {
            var user = await _userService.Register(login, password, cancellation);

            return Created("", new { });
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Login(string login, string password, CancellationToken cancellation)
        {
            var token = await _userService.Login(login, password, cancellation);

            return Ok(token);
        }

    }
}
