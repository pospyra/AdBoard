using AdBoard.AppServices.Ad.Repositories;
using SelectedAd.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Ad.Services
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _adRepository;    

        public AdService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        ///<inheritdoc/>
        public Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip, CancellationToken cancellation)
        {
            return _adRepository.GetAll(take, skip, cancellation);
        }

        ///<inheritdoc/>
        public Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation)
        {
            return _adRepository.GetAllFiltered(request, cancellation);
        }
    }
}
