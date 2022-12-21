using AdBoard.AppServices.Ad.Repositories;
using SelectedAd.Contracts.Photo;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //public async Task<CreatePhotoResponse> AddAPhotoc(CreatePhotoRequest photo, CancellationToken cancellation)
        //{

        //}


        ///<inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            await _photoRepository.DeleteAsync(id, cancellation);
        }
    }
}
