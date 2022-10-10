﻿using SelectedAd.Contracts;

namespace AdBoard.AppServices.SelectedAd.Repositories
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
        /// Удаляет объявление из избранных
        /// </summary>
        /// <param name="id">Идентификтор позиции Избранных пользователя</param>
        /// <param name="cancellation">Отмена операции</param>
        Task DeleteAsync(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает позиции избранных объявлений
        /// </summary>
        /// <param name="cancellation">Отмена операции</param>
        /// <returns>Позиции элементов <see cref="SelectedAdDto"/></returns>
        Task<IReadOnlyCollection<SelectedAdDto>> GetAllAsync(CancellationToken cancellation);
    }
}