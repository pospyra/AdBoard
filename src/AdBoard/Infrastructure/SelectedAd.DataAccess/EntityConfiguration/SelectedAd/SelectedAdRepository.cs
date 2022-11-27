using AdBoard.AppServices;
using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.SelectedAd;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SelectedAd.DataAccess.EntityConfiguration.SelectedAd
{
    /// <summary>
    /// Репозиторий для работы с Избранными объявлениями
    /// </summary>
    public class SelectedAdRepository : ISelectedAdRepository
    {
        private readonly IRepository<SelectedAds> _repository;
        private readonly IRepository<Domain.ItemSelectedAd> _itemRepository;
        private readonly IAdRepository _adRepository;


        public SelectedAdRepository(IRepository<SelectedAds> repository, IAdRepository adRepository, IRepository<Domain.ItemSelectedAd> itemRepository)
        {
            _repository = repository;
            _adRepository = adRepository;
            _itemRepository = itemRepository;
        }

        ///<inheritdoc/>
        public async Task<Guid> AddAdToSelected(Guid selectedId, Guid adId, CancellationToken cancellation)
        {
            var selectedAd = await _repository.GetByIdAsync(selectedId);
            if (selectedAd == null)
                throw new InvalidOperationException($"Вкладки избранных с идентификатором {selectedId} не существует");

             var itemSelectedAd =new Domain.ItemSelectedAd
            {
                SelectedId = selectedId,
                AdId = adId
            };

            await _itemRepository.AddAsync(itemSelectedAd);

            return itemSelectedAd.ItemId;
        }


        ///<inheritdoc/>
        public Task AddAsync(SelectedAds model)
        {
            return _repository.AddAsync(model);
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingSelected = await _repository.GetByIdAsync(id);

            if (existingSelected == null)
            {
                throw new InvalidOperationException($"Избранные пользоваеля с идентификатором {id} не найдено");
            }
            await _repository.DeleteAsync(existingSelected);
        }

        ///<inheritdoc/>
        public async Task<IReadOnlyCollection<SelectedAdDto>> GetAllAsync(CancellationToken cancellation)
        {
            return await _repository.GetAll()
                .Include(s => s.Ad)
                .Select(s => new SelectedAdDto
                {
                    Id = s.Id,
                    AdName = s.Ad.AdName,
                    //Price = s.Price, 
                    Quantity = s.Quantity,
                    
                    
                }).ToListAsync(cancellation);
        }

        public async Task<IReadOnlyCollection<ItemSelectedAdDto>> GetItemAsync(Guid id, CancellationToken cancellation)
        {
            var selectedAd = await _itemRepository.GetByIdAsync(id);

            var adsAll = _itemRepository.GetAll();

            var ads = adsAll.Where(a => a.SelectedId == selectedAd.SelectedId);

            return await ads.Select(s => new ItemSelectedAdDto
            {
               ItemId = s.ItemId,
               SelectedId = s.SelectedId,
               AdId = s.AdId

            }).ToListAsync(cancellation);
        }

        /// <summary>
        /// Удалить объявление из Избранных
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="adId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<SelectedAds> RemoveItemFromSelectedAsync(Guid selectedId, Guid adId, CancellationToken cancellation)
        {
            var selectedAd = await _repository.GetByIdAsync(selectedId);
            if (selectedAd == null)
                return null;

            var ad = await _adRepository.FindById(adId, cancellation);
            if (ad == null)
                return null;

            var itemToRemove =  selectedAd.Ads.FirstOrDefault(c => c.SelectedId == selectedId);
            if (itemToRemove == null)
                throw new InvalidOperationException($"Не удалось выполнить операцию");

            selectedAd.Ads.ToList().Remove(itemToRemove);

            return  selectedAd;
            
        }

        ///<inheritdoc/>
        public async Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
        {
           var existingSelected = await _repository.GetByIdAsync(id);

            if (existingSelected == null)
            {
                throw new InvalidOperationException($"Избранные пользоваеля с идентификатором {id} не найдено");
            }
            existingSelected.Quantity = quantity;
            await _repository.UpdateAsync(existingSelected);

        }
    }
}
