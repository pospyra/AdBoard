using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.User.IRepository;
using SelectedAd.Contracts;
using SelectedAd.Domain;
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

        public async Task<Guid> CreateAdAsync(string adName, Guid category, string description, decimal price, bool possibleOfDelivery)
        {
            var ad = new Ads
            {
                AdName = adName,
                CategoryId = category,
                Description = description,  
                Price = price,
                PossibleOfDelivery = possibleOfDelivery,
                Created = DateTime.UtcNow
            };

            await _adRepository.AddAsync(ad);

            return ad.Id;
        }

        public Task EditAdAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery )
        {
             return _adRepository.EditAsync(id, adName, category, description, price, possibleOfDelivery);
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

        public Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return _adRepository.DeleteAsync(id, cancellation);
        }
    }
}
