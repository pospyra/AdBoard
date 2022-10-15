using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectedAd.Contracts;
using SelectedAd.Domain;


namespace AdBoard.AppServices.User.Services
{
    public interface IUserService
    { 
        /// <summary>
        /// Регистация пользователя
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Индентификтаор пользователя</returns>
         Task <int> Register(string Login, string Password, CancellationToken cancellation);

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns>Токен</returns>
        Task<string> Login(string Login, string Password, CancellationToken cancellation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<User> GetCurrent(CancellationToken cancellation);
    }
}
