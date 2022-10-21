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

        ///<inheritdoc/>
        public Task<Guid> CreateAsync(CancellationToken cancellation)
        {
            return _selectedAdRepository.CreateSelectedAdAsync(cancellation);
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

        ///<inheritdoc/>
        public Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
        {
            return _selectedAdRepository.UpdateQuantityAsync(id, quantity, cancellation);
        }
    }
}
