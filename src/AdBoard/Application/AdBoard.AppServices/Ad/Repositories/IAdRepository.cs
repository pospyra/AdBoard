using SelectedAd.Contracts;
using SelectedAd.Domain;

namespace AdBoard.AppServices.Ad.Repositories
{
    /// <summary>
    /// Интерфейс репозитория чтения/записи для работы с объявлениями.
    /// </summary>
    public interface IAdRepository
    {
        /// <summary>
        /// Возвращает все объявления используя постаничную загрузку
        /// </summary>
        /// <param name="take">Сколько объявлений взять</param>
        /// <param name="skip">Сколько пропустить</param>
        /// <returns>>Коллекция элементов <see cref="AdDto"/></returns>
        Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip, CancellationToken cancellationp);

        /// <summary>
        /// Возвращает объявление по Идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancallation"></param>
        /// <returns></returns>
        Task<Ads> FindById(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает объявления по фильтру
        /// </summary>
        /// <param name="request">Модель фильтра объявления</param>
        /// <param name="cancellation">Отмена операции</param>
        /// <returns>Коллекция элементов <see cref="AdDto"/>.</returns>
        Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation);

        /// <summary>
        /// Добавляет объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task AddAsync(Ads model);

        /// <summary>
        /// Удаляет объявление из избранных
        /// </summary>
        /// <param name="id">Идентификтор позиции Избранных пользователя</param>
        /// <param name="cancellation">Отмена операции</param>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Редактирует объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adName"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="possibleOfDelivery"></param>
        /// <param name="dateOfChange"></param>
        Task EditAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery);
    }
}
