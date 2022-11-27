using AdBoard.AppServices.Ad.Repositories;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Linq;

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
        public AdRepository(IRepository<Ads> repository)
        {
            _repository = repository;
        }


        /// <inheritdoc />
        public Task AddAsync(Ads model)
        {
            return _repository.AddAsync(model);
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingAd = await _repository.GetByIdAsync(id);

            await  _repository.DeleteAsync(existingAd);
        }

        ///<inheritdoc/>
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
       

        public async Task<Ads> FindById(Guid id, CancellationToken cancellation)
        {
            return await _repository.GetByIdAsync(id);
        }


        
       /// <inheritdoc />
       public async Task<IReadOnlyCollection<AdDto>> GetAll( CancellationToken cancellation, int take, int skip)
       {
           return await _repository.GetAll()
               .Select(p => new AdDto
               {
                   Id = p.Id,
                   AdName = p.AdName,
                   Description = p.Description,
                   Price = p.Price,
                   CategoryId = p.CategoryId,
                   SubCategoryId = p.SubCategoryId,
                   UserId = p.UsersId,
                   PossibleOfDelivery = p.PossibleOfDelivery

               }).OrderBy(p => p.Id).Take(skip).Skip((take - 1) * skip).ToListAsync();
           // .Take(take).Skip((take - 1) * skip).ToListAsync(cancellation);
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAdFiltered(string? AdName, Guid CategoryId, bool PossibleOfDelivery, decimal Price, int take, int skip)
        {

            var query = _repository.GetAll();

            if (!string.IsNullOrEmpty(AdName))
            {
                query = _repository.GetAll().Where(p => p.AdName.ToLower().Contains(AdName));
            }

            if (PossibleOfDelivery)
            {
                query = _repository.GetAll().Where(d => d.PossibleOfDelivery == PossibleOfDelivery == true);
            }

            if (Price != null)
            {
                query = _repository.GetAll().Where(d => d.Price == Price == true);
            }

              return await _repository.GetAll().Where(p => p.AdName.ToLower().Contains(AdName)).Select(p => new AdDto
              {
                  Id = p.Id,
                  AdName = p.AdName,
                  Description = p.Description,
                  Price = p.Price,
                  CategoryId = p.CategoryId
              }).OrderBy(p => p.Id).Take(take ).Skip((take - 1) * skip)
              .ToListAsync();
          }


        public async Task<IReadOnlyCollection<AdDto>> GetAdFiltered(string AdName, Guid CategoryId, bool PossibleOfDelivery, decimal Price)
        {
            var query = _repository.GetAll();


            if (!string.IsNullOrEmpty(AdName))
            {
                var ad = _repository.GetAll().Where(p => p.AdName.ToLower().Contains(AdName));
            }

            if (PossibleOfDelivery)
            {
                query = query.Where(d => d.PossibleOfDelivery == PossibleOfDelivery == true);
            }

            if (Price != null)
            {
                query = query.Where(d => d.Price == Price == true);
            }

            return await query.Select(p => new AdDto
            {
                Id = p.Id,
                AdName = p.AdName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).OrderBy(p => p.Id)//.Take(take).Skip( skip).ToListAsync(cancellation);
                                 .ToListAsync();
        }
        ///<inheritdoc/>
        public async Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request)
        {
            var query = await _repository.GetAllAsync();

            if (request == null)
                throw new NullReferenceException("Не задан фильтр");

            if (request.Id.HasValue)
            {
                query = query.Where(p => p.Id == request.Id);
            }

            if (!string.IsNullOrEmpty(request.AdName))
            {
                query = query.Where(p => p.AdName.ToLower().Contains(request.AdName));
            }

            if (request.CategoryId.HasValue)
            {
                query = query.Where(c => c.CategoryId == request.CategoryId);
            }

            if (request.PossibleOfDelivery == true)
            {
                query = query.Where(d => d.PossibleOfDelivery == request.PossibleOfDelivery == true);
            }


            return await query.Select(p => new AdDto
            {
                Id = p.Id,
                AdName = p.AdName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).Skip((request.CurrentPage - 1) * request.Size).Take(request.Size)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAll(PagingFilter paging)
        {
            return await _repository.GetAll()
                .Select(p => new AdDto
                {
                    Id = p.Id,
                    AdName = p.AdName,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    SubCategoryId = p.SubCategoryId,
                    UserId = p.UsersId,
                    PossibleOfDelivery = p.PossibleOfDelivery

                }).Skip((paging.CurrentPage - 1) * paging.Size).Take(paging.Size)
                .ToListAsync();
        }

        //сорировка по цене верх-вниз

        //поиск по объявлениями
    }
}
  
