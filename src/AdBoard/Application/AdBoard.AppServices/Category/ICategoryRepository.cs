using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Category
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Добавляет категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task AddAsync(Categories model);

        /// <summary>
        /// Получить все категории
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<Categories>> GetAll(CancellationToken cancellation);

        Task<IReadOnlyCollection<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellation);

        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id">Идентификтор позиции Избранных пользователя</param>
        /// <param name="cancellation">Отмена операции</param>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Редактирует категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adName"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="possibleOfDelivery"></param>
        /// <param name="dateOfChange"></param>
        Task EditAsync(Guid id, string Name, CancellationToken cancellation);
    }
}
