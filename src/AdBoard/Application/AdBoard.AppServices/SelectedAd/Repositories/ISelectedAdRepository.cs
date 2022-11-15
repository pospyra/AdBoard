using SelectedAd.Contracts;
using SelectedAd.Domain;

namespace AdBoard.AppServices
{
    /// <summary>
    /// Работа с избранными объявлениями.
    /// </summary>
    public interface ISelectedAdRepository
    {
        /// <summary>
        /// Обновляет количество объявлений в избранных.
        /// </summary>
        /// <param name="id">Идентификатор позиции Избранных пользователя</param>
        /// <param name="quantity">Новое количество товара</param>
        /// <param name="cancellation">Отмена операции</param>
        Task UpdateQuantityAsync(Guid id,int quantity, CancellationToken cancellation);

        /// <summary>
        /// Возвращает позиции избранных объявлений
        /// </summary>
        /// <param name="cancellation">Отмена операции</param>
        /// <returns>Позиции элементов <see cref="SelectedAdDto"/></returns>
        Task<IReadOnlyCollection<SelectedAdDto>> GetAllAsync(CancellationToken cancellation);

        /// <summary>
        /// Удаляет вкладку Избранныхх
        /// </summary>
        /// <param name="id">Идентификтор позиции Избранных пользователя</param>
        /// <param name="cancellation">Отмена операции</param>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Создает вкладку с Избранными объявлениями
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(SelectedAds model);

        /// <summary>
        /// Добавляет объявление в Избранное
        /// </summary>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        // Task AddAdAsync( Guid id, Ads ads, CancellationToken cancelToken);

        /// <summary>
        /// Удаляет элемент из Избранных
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="ad"></param>
        /// <returns></returns>
         Task<SelectedAds> RemoveItemFromSelectedAsync(Guid selectedId, Guid adId, CancellationToken cancellation);

        /// <summary>
        /// Добавить объявление в Избранные
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="adId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Guid> AddAdToSelected(Guid selectedId, Guid adId, CancellationToken cancellation);
    }
}