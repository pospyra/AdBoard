using AdBoard.AppServices.Ad.Repositories;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdBoard.AppServices.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        ///<inheritdoc/>
        public async Task<Guid> AddAPhotosync(Photo photo, CancellationToken cancellation)
        { 
            await _photoRepository.AddPhotoAsync(photo);

            return photo.Id;
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            await _photoRepository.DeleteAsync(id, cancellation);
        }
    }
}
