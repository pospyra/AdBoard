using AdBoard.AppServices.Ad.Repositories;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;

namespace SelectedAd.DataAccess.EntityConfiguration.Ad
{
    public class AdRepository : IAdRepository
    {
        private readonly IRepository<Domain.Ad> _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="cref = "AdRepository"/>
        /// </summary>
        /// <param name="repository">Базовый репозиторий</param>
        public AdRepository(IRepository<Domain.Ad> repository)
        {
            _repository = repository;
        }

        
        /// <inheritdoc />
        public async Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip, CancellationToken cancellation)
        {
            return await _repository.GetAll()
                .Select(p => new AdDto
                {
                    Id = p.Id,
                    AdName = p.AdName,
                    Description = p.Description,
                    Price = p.Price
                })
                .Take(take).Skip(skip).ToListAsync(cancellation);
        }
        
        public async Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation)
        {
            var query = _repository.GetAll();

            if (request.Id.HasValue)
            {
                query = query.Where(p => p.Id == request.Id);
            }

            if (!string.IsNullOrEmpty(request.AdName))
            {
                query = query.Where(p => p.AdName.ToLower().Contains(request.AdName));
            }

            return await query.Select(p => new AdDto
            {
                Id = p.Id,
                AdName = p.AdName,
                Description = p.Description,
                Price = p.Price
            }).ToListAsync(cancellation);
        }
    }
}
  
