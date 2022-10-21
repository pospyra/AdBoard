﻿using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.User.IRepository;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System.Linq.Expressions;

namespace SelectedAd.DataAccess.EntityConfiguration.User
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.Users> _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref = "UserRepository"/>
        /// </summary>
        /// <param name="repository">Базовый репозиторий</param>
        public UserRepository(IRepository<Domain.Users> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task AddAsync(Users model)
        {
            return _repository.AddAsync(model);
        }

        /// <summary>
        /// Находит пользователя по фильтру
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancallation"></param>
        /// <returns></returns>
        public async Task<Users> FindWhere(Expression<Func<Users, bool>> predicate, CancellationToken cancallation)
        {
           var data = _repository.GetAllFiltered(predicate);

            return await data.Where(predicate).FirstOrDefaultAsync(cancallation);
        }

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">Идентификтаор</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingAd = await _repository.GetByIdAsync(id);

            if (existingAd == null)
            {
                throw new InvalidOperationException($"Пользователь с идентификатором {id} не найден");
            }
            await _repository.DeleteAsync(existingAd);
        }

        public async Task EditAsync(Guid id, string name, string login, string password, string number, string email, string region)
        {
            var existingAd = await _repository.GetByIdAsync(id);

            if (existingAd == null)
            {
                throw new InvalidOperationException($"Пользователь пользоваеля с идентификатором {id} не найдено");
            }
            existingAd.Name = name;
            existingAd.Login = login;
            existingAd.Password = password;
            existingAd.Number = number;
            existingAd.Email = email;
            existingAd.Region = region;

            await _repository.UpdateAsync(existingAd);
        }




        /*
        /// <inheritdoc />
        public async Task<IReadOnlyCollection<UserDto>> GetAll(int take, int skip, CancellationToken cancellation)
        {
            return await _repository.GetAll()
                .Select(p => new UserDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    
                })
                .Take(take).Skip(skip).ToListAsync(cancellation);
        }*/

    }
}
  
