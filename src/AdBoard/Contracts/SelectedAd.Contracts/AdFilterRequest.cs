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
    public class AdFilterRequest
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string AdName { get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        public decimal Price { get; set; }
    }
}
