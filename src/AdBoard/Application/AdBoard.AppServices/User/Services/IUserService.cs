using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System.Linq.Expressions;

namespace AdBoard { 

    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
  

        /// <summary>
        /// Получить Id текщего пользователя
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Guid> GetCurrentUserId(CancellationToken cancellation);

        /// <summary>
        /// Регистрация Пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Guid> Registration(UserRegister user);

        /// <summary>
        /// Аутентификация Пользователя
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        Task<string> Login(UserLogin userLogin);

         Task<IReadOnlyCollection<UserDto>> GetUsers(CancellationToken cancellation);

        /// <summary>
        /// Старая Регистрация пользователя.
        /// </summary>
        /// <param name="Login">Логин.</param>
        /// <param name="Password">Пароль.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Идентификатор пользователя.</returns>
        Task<Guid> Register(string login, string name, string password, string number, string email, string region);
       
        /// <summary>
        /// Старыый логин
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Токен.</returns>
        Task<string> Login(string login, string password);

            /// <summary>
            /// Удалить Пользователя
            /// </summary>
            /// <param name="id"></param>
            /// <param name="cancellation"></param>
            /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Редактирует данные Пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="number"></param>
        /// <param name="email"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        Task EditAsync(Guid id, string name, string login, string password, string number, string email, string region);

        /// <summary>
        /// Получить текущего Пользователя
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Users> GetCurrent(CancellationToken cancellation);
    }
}