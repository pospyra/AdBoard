using SelectedAd.Contracts.Photo;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Photos
{
    public interface IPhotoService
    {
        /// <summary>
        /// Удаляет фото 
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellation"></param>
        public Task DeleteAsync(Guid id, CancellationToken cancellation);


        Task SetAdPhoto(SetAdPhotoRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет фото
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// 
        Task<CreatePhotoResponse> AddAdPhoto(CreatePhotoRequest photo, CancellationToken cancellation);

       // Task<Guid> AddAdPhoto(Photo photo, CancellationToken cancellation);
    }
}
