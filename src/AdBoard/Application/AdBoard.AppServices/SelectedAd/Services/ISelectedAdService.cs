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
        Task<Guid> CreateSelectedAsync(Guid userId ,Guid adId, CancellationToken cancellation);

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
        /// Удаляет вкладку Избранных.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Удаляет объявление из Избранных
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="adId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task RemoveItemSelected(Guid selectedId, Guid adId, CancellationToken cancellation);

        /// <summary>
        /// Добавляет объявление в Избранное
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="adId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task AddItemSelected(Guid selectedId, Guid adId, CancellationToken cancellation);
    }
}
