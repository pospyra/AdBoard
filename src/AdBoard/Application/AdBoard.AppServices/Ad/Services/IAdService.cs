﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectedAd.Domain;
using SelectedAd.Contracts.Ad;

namespace AdBoard.AppServices.Ad.Services
{
    /// <summary>
    /// Сервис для работы с объявлениями
    /// </summary>
    public interface IAdService
    {
        /// <summary>
        /// Вернуть объявление по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<Ads> GetByIdAsync(Guid id);

        /// <summary>
        /// Создание объявления
        /// </summary>
        /// <param name="createAd"></param>
        /// <returns></returns>
        Task<Guid> CreateAdAsync(CreateAdDto createAd, CancellationToken cancellation);



        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <param name="take">Сколько объявлений взять</param>
        /// <param name="skip">Сколько пропустить</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<AdDto>> GetAll( CancellationToken cancellation, int take, int skip);

       
        /// <summary>
        /// Получить объявления по фильтру
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        //  Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request);
        Task<IReadOnlyCollection<AdDto>> GetAdFiltered(Guid? userId, string? AdName, Guid? CategoryId, bool? PossibleOfDelivery, int take, int skip);


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


        Task EditAdAsync(EditAdDto edit);


        /// <summary>
        /// Создает объявление
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<Guid> CreateAdAsync(string adName, Guid categoryId, Guid sunCategoryId, string description, decimal price, bool possibleOfDelivery, Guid userId, CancellationToken cancellation);


        Task<IReadOnlyCollection<AdDto>> GetAllFiltered(AdFilterRequest request);


    }
}
