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
    }
}
