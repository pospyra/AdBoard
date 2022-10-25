using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Photos
{
    public interface IPhotoRepository
    {
        /// <summary>
        /// Добавляет объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task AddPhotoAsync(Photo model);

        /// <summary>
        /// Удаляет объявление из избранных
        /// </summary>
        /// <param name="id">Идентификтор позиции Избранных пользователя</param>
        /// <param name="cancellation">Отмена операции</param>
        Task DeleteAsync(Guid id, CancellationToken cancellation);


    }
}
