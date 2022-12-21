using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.User.IRepository;
using SelectedAd.Contracts.Ad;
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
        private readonly IUserService _userService;

        public AdService(IAdRepository adRepository, IUserService userService)
        {
            _adRepository = adRepository;
            _userService = userService;
        }

        ///<inheritdoc/>
        public async Task<Guid> CreateAdAsync(CreateAdDto createAd, CancellationToken cancellation)
        {
            var currentUser =  await _userService.GetCurrentUserId(cancellation);
            var ad = new Ads
            {
                AdName = createAd.AdName,
                CategoryId = createAd.CategoryId,
                Description = createAd.Description,
                Price = createAd.Price,
                PossibleOfDelivery = createAd.PossibleDelivery,
                UsersId = currentUser,
                Created = DateTime.UtcNow,
                Region = createAd.Region
                
            };

            await _adRepository.AddAsync(ad);

            return ad.Id;
        }

        ///<inheritdoc/>
        public Task EditAdAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery)
        {
            return _adRepository.EditAsync(id, adName, category, description, price, possibleOfDelivery);
        }


        public Task EditAdAsync( EditAdDto edit)
        {
            return _adRepository.EditAdAsync(edit);
        }

        ///<inheritdoc/>
        public Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return _adRepository.DeleteAsync(id, cancellation);
        }

        ///<inheritdoc/>
        public Task<IReadOnlyCollection<AdDto>> GetAdFiltered(Guid? userId, string? AdName, Guid? CategoryId, bool? PossibleOfDelivery, int take, int skip)
        {
           return _adRepository.GetAdFiltered(userId, AdName, CategoryId, PossibleOfDelivery, take, skip);
        }

        ///<inheritdoc/>
        public Task<IReadOnlyCollection<AdDto>> GetAll(CancellationToken cancellation, int take, int skip)
        {
            return _adRepository.GetAll(cancellation, take, skip);
        }

        public async Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request)
        {
            return await  _adRepository.GetAllFiltered(request);
        }


        ///<inheritdoc/>
        public async Task<Guid> CreateAdAsync(string adName, Guid categoryId, Guid sunCategoryId, string description, decimal price, bool possibleOfDelivery, Guid userId, CancellationToken cancellation)
        {
            var currentUser = await _userService.GetCurrentUserId(cancellation);
            var ad = new Ads
            {
                AdName = adName,
                CategoryId = categoryId,
                SubCategoryId = sunCategoryId,
                Description = description,
                Price = price,
                PossibleOfDelivery = possibleOfDelivery,
                UsersId = currentUser,
                Created = DateTime.UtcNow,

            };

            await _adRepository.AddAsync(ad);

            return ad.Id;
        }

        public async Task<Ads> GetByIdAsync(Guid id)
        {
           return await _adRepository.GetByIdAsync(id);
        }
    }
}
