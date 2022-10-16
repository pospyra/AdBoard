using SelectedAd.Contracts;
using SelectedAd.Domain;

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
        Task<int> Register(string login, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Залогиниться.
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Токен.</returns>
        Task<string> Login(string login, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> GetCurrent(CancellationToken cancellationToken);
    }
}