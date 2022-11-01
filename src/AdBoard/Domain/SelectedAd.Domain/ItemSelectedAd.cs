using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Domain
{
    /// <summary>
    /// Объявления в Избранных
    /// </summary>
    public class ItemSelectedAd
    {
        /// <summary>
        /// Идентификатор вкладки избранных.
        /// </summary>
        public Guid SelectedId { get; set; }

        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid AdId { get; set; }

        /// <summary>
        /// Объявление.
        /// </summary>
        public Ads Ad { get; set; }

        /// <summary>
        /// Избранные
        /// </summary>
        public SelectedAds SelectedAds { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Количество объявлений.
        /// </summary>
        public int? Quantity { get; set; }




    }
}
