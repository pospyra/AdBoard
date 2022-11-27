using System.Linq.Expressions;

namespace AdBoard.Infrastructure.Repository
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        ///<summary>
        ///Получить все элменты сущности.
        ///</summary>
        /// <returns> Все элементы сущности <see cref="TEntity"/>.</returns>
        IQueryable<TEntity> GetAll();

        Task<IQueryable<TEntity>> GetAllAsync();

        ///<summary>
        ///Возвращает все значения по фильтру
        ///</summary>
        /// <param name="filter">Фильтр.</param>
        ///<returns>Все элементы сущности <see cref="TEntity"/> по фильтру.</returns>
        IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> filter);

        ///<summary>
        ///Возвращает все значения <see cref="TEntity"/> по Id
        ///</summary>
        ///<param name="Id"> Идентификатор <see cref="TEntity"/>.</param>
        Task<TEntity> GetByIdAsync(Guid Id);

        ///<summary>
        ///Добавить элемент <see cref="TEntity"/>
        ///</summary>
        ///<param name="model"> Новая сущность <see cref="TEntity"/>.</param>
        Task AddAsync(TEntity model);

        /// <summary>
        /// Обновляет элемент <see cref="TEntity"/>.
        /// </summary>
        /// <param name="model">Существующая сущность <see cref="TEntity"/>.</param>
        Task UpdateAsync(TEntity model);

        /// <summary>
        /// Удаляет элемент <see cref="TEntity"/>.
        /// </summary>
        /// <param name="model">Существующая сущность <see cref="TEntity"/>.</param>
        Task DeleteAsync(TEntity model);
    }
}

