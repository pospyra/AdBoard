using AdBoard.AppServices.Photos;
using AdBoard.Infrastructure.Repository;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess.EntityConfiguration.Photo
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IRepository<Domain.Photo> _repository;

        /// <summary>
        /// Репозиторий для фото
        /// </summary>
        /// <param name="repository"></param>
        public PhotoRepository(IRepository<Domain.Photo> repository)
        {
            _repository = repository;
        }

        public Task AddPhotoAsync(Domain.Photo model)
        {
            return _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingPhoto = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(existingPhoto);
        }
    }
}
