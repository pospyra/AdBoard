using AdBoard.AppServices.Ad.Repositories;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;
using SelectedAd.Domain;

namespace SelectedAd.DataAccess.EntityConfiguration.Ad
{
    /// <inheritdoc />
    public class AdRepository : IAdRepository
    {
        private readonly IRepository<Ads> _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="cref = "AdRepository"/>
        /// </summary>
        /// <param name="repository">Базовый репозиторий</param>
        public AdRepository(IRepository<Domain.Ads> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Task AddAsync(Ads model)
        {
            return _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingAd = await _repository.GetByIdAsync(id);

            await  _repository.DeleteAsync(existingAd);
        }

        public async Task EditAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery)
        {
            var existingAd = await _repository.GetByIdAsync(id);

            if (existingAd == null)
            {
                throw new InvalidOperationException($"Объявление пользоваеля с идентификатором {id} не найдено");
            }
            existingAd.AdName = adName;
            existingAd.CategoryId = category;
            existingAd.Description = description;
            existingAd.Price = price;
            existingAd.PossibleOfDelivery = possibleOfDelivery;
            existingAd.Created = DateTime.UtcNow;

            await _repository.UpdateAsync(existingAd);
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
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).ToListAsync(cancellation);
        }
    }
}
  
