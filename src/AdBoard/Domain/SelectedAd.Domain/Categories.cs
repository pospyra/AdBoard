using SelectedAd.Contracts;
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
        /// Наименование категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Коллекция элементов объявлений.
        /// </summary>
        public ICollection<Ads> Ad { get; set; }

        /// <summary>
        /// Коллекция элементов подкатегорий
        /// </summary>
        public ICollection<SubCategory> SubCategories { get; set; }

    }
}

