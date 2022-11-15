 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    /// <summary>
    /// Модель представления категории объявлений.
    /// </summary>
    public class CategoryDto
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
        /// Идентификатор подкатегории
        /// </summary>
        public Guid SubCategoryId { get; set; }

        /// <summary>
        /// Наименование подкатегории
        /// </summary>
        public string SubCategoryName { get; set; }
    }
}
