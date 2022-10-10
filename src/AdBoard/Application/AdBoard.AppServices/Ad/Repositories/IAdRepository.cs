using SelectedAd.Contracts;

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
        /// Возвращает объявления по фильтру
        /// </summary>
        /// <param name="request">Модель фильтра объявления</param>
        /// <param name="cancellation">Отмена операции</param>
        /// <returns>Коллекция элементов <see cref="AdDto"/>.</returns>
        Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation);
    }
}
