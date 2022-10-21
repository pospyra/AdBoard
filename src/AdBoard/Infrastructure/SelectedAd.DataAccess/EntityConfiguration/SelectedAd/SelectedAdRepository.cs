using AdBoard.AppServices;
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

namespace SelectedAd.DataAccess.EntityConfiguration.SelectedAd
{
    public class SelectedAdRepository : ISelectedAdRepository
    {
        private readonly IRepository<SelectedAds> _repository;

        public SelectedAdRepository(IRepository<SelectedAds> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateSelectedAdAsync(CancellationToken cancellation)
        {
            var selectedAd = new SelectedAds();

            await _repository.AddAsync(selectedAd);

            return selectedAd.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingSelected = await _repository.GetByIdAsync(id);

            if (existingSelected == null)
            {
                throw new InvalidOperationException($"Избранные пользоваеля с идентификатором {id} не найдено");
            }
            await _repository.DeleteAsync(existingSelected);
        }

        public async Task<IReadOnlyCollection<SelectedAdDto>> GetAllAsync(CancellationToken cancellation)
        {
            return await _repository.GetAll()
                .Include(s => s.Ad)
                .Select(s => new SelectedAdDto
                {
                    Id = s.Id,
                    AdName = s.Ad.AdName,
                    Price = s.Price, 
                    Quantity = s.Quantity
                    
                }).ToListAsync(cancellation);
        }

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
