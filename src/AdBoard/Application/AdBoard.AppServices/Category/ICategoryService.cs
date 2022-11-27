using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Category
{
    public interface ICategoryService
    {
        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Создать Категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Guid> CreateCategoryAsync( string name);

        /// <summary>
        /// Редактировать Категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task EditCategoryAsync(Guid id, string name, CancellationToken cancellation);

        /// <summary>
        /// Получить все категории
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<Categories>> GetAllCategory(CancellationToken cancellation);

        Task<IReadOnlyCollection<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellation);
    }
}
