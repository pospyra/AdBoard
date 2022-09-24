using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    /// <summary>
    /// Модель представления избранных объявлений.
    /// </summary>
    public class SelectedAdDto
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
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество объявлений 
        /// </summary>
        public int Quantity { get; set; }
    }
}
