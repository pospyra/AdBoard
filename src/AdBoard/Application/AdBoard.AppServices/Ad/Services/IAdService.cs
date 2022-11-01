using SelectedAd.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectedAd.Domain;

namespace AdBoard.AppServices.Ad.Services
{
    /// <summary>
    /// Сервис для работы с объявлениями
    /// </summary>
    public interface IAdService
    {
        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <param name="take">Сколько объявлений взять</param>
        /// <param name="skip">Сколько пропустить</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdDto>> GetAll(int take, int skip, CancellationToken cancellation);

        /// <summary>
        /// Получить объявления по фильтру
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request, CancellationToken cancellation);

        /// <summary>
        /// Создает объявление
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Guid> CreateAdAsync( string adName, Guid categoryId, string description, decimal price, bool possibleOfDelivery, Guid userId);

        /// <summary>
        /// Удаляет объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Редактирует объявление
        /// </summary>
        /// <param name="adName"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="possibleOfDelivery"></param>
        /// <returns></returns>
        Task EditAdAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery);
    }
}
