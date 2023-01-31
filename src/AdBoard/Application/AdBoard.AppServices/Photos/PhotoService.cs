using AdBoard.AppServices.Ad.Repositories;
using AutoMapper;
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

        public async Task<CreatePhotoResponse> AddAdPhoto(CreatePhotoRequest request, CancellationToken cancellation) //дл\ добавления фото в бд
        {
            if (request.Photo.Length > 5242880)
            {
                throw new Exception("Слишклм большой размер");
            }

            var photos = new Photo()
            {
                KodBase64 = Convert.ToBase64String(request.Photo, 0, request.Photo.Length)
            };

            await _photoRepository.AddPhotoAsync(photos);

            var res = new CreatePhotoResponse
            {
                Id = photos.Id
            };
            return res;
        }

        //public async Task<Guid> AddAdPhoto(Photo photo, CancellationToken cancellation)
        //{
        //    if (photo.BytePhoto.Length > 5242880)
        //    {
        //        throw new Exception("Слишклм большой размер");
        //    }

        //    var photos = new Photo()
        //    {
        //        KodBase64 = Convert.ToBase64String(photo.BytePhoto, 0, photo.BytePhoto.Length)
        //    };

        //    await _photoRepository.AddPhotoAsync(photos);

        //    return photos.Id;
        //}


        ///<inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            await _photoRepository.DeleteAsync(id, cancellation);
        }

        public async Task SetAdPhoto(SetAdPhotoRequest request, CancellationToken cancellation) //дл\ добавлния фото у объявлению
        {
            var photo = await _photoRepository.FindById(request.Id, cancellation);

            photo.AdId = request.AdId;

            await _photoRepository.UpdatePhotoAsync(photo);

            // await _photoRepository.AddPhotoAsync(photo);
        }

    }
}
