using AdBoard.AppServices.User.Services;
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
    }
}
