using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.User.IRepository
{
    public interface IUserRepository 
    {
        Task<Users> FindWhere(Expression<Func<Users, bool>> predicate, CancellationToken cancallation);

        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(Users model);

        /// <summary>
        /// Удаляет Пользоватея
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