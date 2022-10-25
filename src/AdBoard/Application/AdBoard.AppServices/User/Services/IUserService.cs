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
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="Login">Логин.</param>
        /// <param name="Password">Пароль.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Идентификатор пользователя.</returns>
        Task<Guid> Register(string login, string name, string password, string number, string email, string region, CancellationToken cancellation);

        /// <summary>
        /// Залогиниться.
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Токен.</returns>
        Task<string> Login(string login, string password, CancellationToken cancellationToken);

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

    }
}