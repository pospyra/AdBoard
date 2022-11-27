using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    /// <summary>
    /// Модель представления объявлений по фильтру.
    /// </summary>
    /// <summary>
    /// Модель фильтра товаров.
    /// </summary>
    public class AdFilterRequest : PagingFilter
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string? AdName { get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Возможность доставки
        /// </summary>
        public bool PossibleOfDelivery { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal? Price { get; set; }
    }
}
