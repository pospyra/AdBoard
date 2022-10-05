using SelectedAd.Contracts;

namespace AdBoard.AppServices.Ad.Repositories
{
    public interface IAdRepository
    {
        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <param name="take">Сколько объявлений взять</param>
        /// <param name="skip">Сколько пропустить</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip, CancellationToken cancellationp);
        

        /// <summary>
        /// Получить объявления по фильтру
        /// </summary>
        /// <param name="request">Модель фильтра объявления</param>
        /// <returns>Коллекция элементов <see cref="AdDto"/>.</returns>
        Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation);
    }
}
