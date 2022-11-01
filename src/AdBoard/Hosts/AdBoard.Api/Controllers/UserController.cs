using AdBoard.AppServices.User;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Регистрирует Пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="name">Имя</param>
        /// <param name="password">Пароль</param>
        /// <param name="number">Номер телефона</param>
        /// <param name="email">Email</param>
        /// <param name="region">Регион</param>
        /// <param name="cancellation">Отмена действия</param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(string login, string name, string password, string number, string email, string region, CancellationToken cancellation)
        {
            var user = await _userService.Register(login, password, name, number, email, region, cancellation);

            return Created("", new { });
        }

        /// <summary>
        /// Залогинить пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Login(string login, string password, CancellationToken cancellation)
        {
            var token = await _userService.Login(login, password, cancellation);

            return Ok(token);
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
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
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
    }
}
