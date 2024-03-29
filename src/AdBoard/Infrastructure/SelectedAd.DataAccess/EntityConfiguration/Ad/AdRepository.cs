﻿using AdBoard.AppServices.Ad.Repositories;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts.Ad;
using SelectedAd.Domain;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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

            await _repository.DeleteAsync(existingAd);
        }

        public async Task<Ads> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);

        }

        ///<inheritdoc/>
        public async Task EditAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery)
        {
            var existingAd = await _repository.GetByIdAsync(id);

            if (existingAd == null)
            {
                throw new InvalidOperationException($"Объявление с идентификатором {id} не найдено");
            }
            existingAd.AdName = adName;
            existingAd.CategoryId = category;
            existingAd.Description = description;
            existingAd.Price = price;
            existingAd.PossibleOfDelivery = possibleOfDelivery;
            existingAd.Created = DateTime.UtcNow;

            await _repository.UpdateAsync(existingAd);
        }


        public async Task EditAdAsync (EditAdDto edit)
        {
            var existingAd = await _repository.GetByIdAsync(edit.Id);

            if (existingAd == null)
            {
                throw new InvalidOperationException($"Объявление с идентификатором {edit.Id} не найдено");
            }
            existingAd.AdName = edit.AdName;
            existingAd.CategoryId = edit.CategoryId;
            existingAd.Description = edit.Description;
            existingAd.Price = edit.Price;
            existingAd.PossibleOfDelivery = edit.PossibleDelivery;
            existingAd.Created = DateTime.UtcNow;

            await _repository.UpdateAsync(existingAd);
        }

        public async Task<Ads> FindById(Guid id, CancellationToken cancellation)
        {
            return await _repository.GetByIdAsync(id);
        }



        /// <inheritdoc />
        public async Task<IReadOnlyCollection<AdDto>> GetAll(CancellationToken cancellation, int take, int skip)
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

                }).OrderBy(p => p.Id).Skip((take - 1) * skip).Take(skip).ToListAsync();
            // .Take(take).Skip((take - 1) * skip).ToListAsync(cancellation);
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAdFiltered(Guid? userId, string? AdName, Guid? CategoryId, bool? PossibleOfDelivery, int take, int skip)
        {

            var query = _repository.GetAll();

            if (userId != null)
            {
                query = query.Where(p => p.UsersId == userId);
            }


            if (!string.IsNullOrEmpty(AdName))
            {
                query = query.Where(p => p.AdName.ToLower().Contains(AdName));
            }

            if (CategoryId != null)
            {
                query = query.Where(d => d.CategoryId == CategoryId);
            }

            if (PossibleOfDelivery!=null)
            {
                query = query.Where(d => d.PossibleOfDelivery == PossibleOfDelivery == true);
            }

            return await query.Select(p => new AdDto
            {
                Id = p.Id,
                AdName = p.AdName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).OrderBy(p => p.Id).Skip((take - 1) * skip).Take(skip).ToListAsync();
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

            if (request.Price.HasValue)
            {
                query = query.Where(p => p.Price == request.Price);
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

        //сорировка по цене верх-вниз

        //поиск по объявлениями
    }
}
  
