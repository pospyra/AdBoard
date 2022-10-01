using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Domain
{
    public class Categories
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Объявление.
        /// </summary>

        /// <summary>
        /// Коллекция элементов объявлений.
        /// </summary>
        public ICollection<Ad> Ad { get; set; }
    }
}

