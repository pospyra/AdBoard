using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.User.IRepository;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;

namespace SelectedAd.DataAccess.EntityConfiguration.User
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.User> _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref = "UserRepository"/>
        /// </summary>
        /// <param name="repository">Базовый репозиторий</param>
        public UserRepository(IRepository<Domain.User> repository)
        {
            _repository = repository;
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
  
