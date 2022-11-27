using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.SelectedAd;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.SelectedAd.Services
{
    /// <inheritdoc/>
    public class SelectedAdService : ISelectedAdService
    {
        private readonly ISelectedAdRepository _selectedAdRepository;

        public SelectedAdService(ISelectedAdRepository selectedAdRepository)
        {
            _selectedAdRepository = selectedAdRepository;
        }

        public Task AddItemSelected(Guid selectedId, Guid adId, CancellationToken cancellation)
        {
            return _selectedAdRepository.AddAdToSelected(selectedId, adId,cancellation);
        }

        ///<inheritdoc/>
        public async Task<Guid> CreateSelectedAsync(Guid userId ,Guid adId, CancellationToken cancellation)
        {
            var selected = new SelectedAds
            {
                UserId = userId,
                AdId = adId
            };
            await _selectedAdRepository.AddAsync(selected);

            return selected.Id;
        }

        ///<inheritdoc/>
        public Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return _selectedAdRepository.DeleteAsync(id, cancellation);
        }

        ///<inheritdoc/>
        public Task<IReadOnlyCollection<SelectedAdDto>> GetAsync(CancellationToken cancellation)
        {
            return _selectedAdRepository.GetAllAsync(cancellation);
        }

        public Task<IReadOnlyCollection<ItemSelectedAdDto>> GetItemSelectedAsync(Guid id,CancellationToken cancellation)
        {
            return _selectedAdRepository.GetItemAsync(id, cancellation);
        }

        ///<inheritdoc/>
        public Task RemoveItemSelected(Guid selectedId, Guid adId, CancellationToken cancellation)
        {
            return _selectedAdRepository.RemoveItemFromSelectedAsync(selectedId, adId, cancellation);
        }

        ///<inheritdoc/>
        public Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
        {
            return _selectedAdRepository.UpdateQuantityAsync(id, quantity, cancellation);
        }

    }
}
