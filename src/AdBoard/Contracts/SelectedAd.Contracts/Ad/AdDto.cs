using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts.Ad
{
    /// <summary>
    /// Модель представления объявлений.
    /// </summary>
    public class AdDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование объявления.
        /// </summary>
        public string AdName { get; set; }

        /// <summary>
        /// Идентификатор Категории объявления.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Идентификатор Подкатегории объявления.
        /// </summary>
        public Guid? SubCategoryId { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Возомжность доставки
        /// </summary>
        public bool PossibleOfDelivery { get; set; }

        public Guid? UserId { get; set; }
    }
}
