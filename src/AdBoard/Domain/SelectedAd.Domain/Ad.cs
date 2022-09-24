using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Domain
{
    /// <summary>
    /// Объявление.
    /// </summary>
    public class Ad
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
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        public ICollection<SelectedAds> SelectedAds { get; set; }

    }
}
