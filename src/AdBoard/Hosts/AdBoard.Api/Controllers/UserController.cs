using AdBoard.AppServices.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System.Linq.Expressions;
using System.Net;

namespace AdBoard.Api.Controllers
{
    /// <summary>
    /// Работа с Пользователями
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Route("v1/[controller]")]

    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Регистрация Пользователей
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// Потом сама если что роут изменишь И ТАМ И ТАМ
        [Route("api/[controller]/[action]")]
        [HttpPost()]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registration(UserRegister user)
        {
            var userReg = await _userService.Registration(user);

            return Created("", userReg);
        }

        /// <summary>
        /// Аутентификация Пользователя
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var token = await _userService.Login(userLogin);

            return Ok(new { Token = token, Message = "Success" });
        }

        /// <summary>
        /// Возвращает всех Пользователей
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllUser(CancellationToken cancellation)
        {
            var result = await _userService.GetUsers(cancellation);
            return Ok(result);
        }

        [HttpGet("usreId")]
        [ProducesResponseType(typeof(IReadOnlyCollection<Users>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCurrenUserI(CancellationToken cancellation)
        {
            var result = await _userService.GetCurrentUserId(cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Редактировать данные Пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="number"></param>
        /// <param name="email"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditAdAsync(Guid id, string name, string login, string password, string number, string email, string region)
        {
            await _userService.EditAsync(id, name, login, password, number, email, region);

            return Ok();
        }

        /// <summary>
        /// Удаляет Пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken cancellation)
        {
            await _userService.DeleteAsync(id, cancellation);
            return NoContent();
        }


        
        /// <summary>
        /// Старая аутентификация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("loginnnn")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(string login, string password)
        {
            var token = await _userService.Login(login, password);

            return Ok(token);
        }

        /*
        /// <summary>
        /// Возвращает Пользователей по фильтру
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(Expression<Func<Users, bool>> predicate, CancellationToken cancellation)
        {
            var result = await _userService.FindWhere(predicate, cancellation);

            return Ok(result);
        }*/
    }
}
