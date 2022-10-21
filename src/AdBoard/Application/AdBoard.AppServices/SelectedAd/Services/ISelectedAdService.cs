using SelectedAd.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.SelectedAd.Services
{ 
    /// <summary>
    /// Сервис для работы с избранными объявлениями.
    /// </summary>
    public interface ISelectedAdService 
    {
        /// <summary>
        /// Добавляет вкладку с Избранными объявлениями
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Guid> CreateAsync(CancellationToken cancellation);

        /// <summary>
        /// Возвращет позиции избранных объявлений.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<SelectedAdDto>> GetAsync(CancellationToken cancellation);

        /// <summary>
        /// Обновляет объявление из избранных.
        /// </summary>
        /// <param name="id">Индентификатор позиции Избранных пользователя</param>
        /// <param name="quantity">Новое количество объявлений.</param>
        Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation);

        /// <summary>
        /// Удаляет объявление из избранных.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellation);
    }
}
