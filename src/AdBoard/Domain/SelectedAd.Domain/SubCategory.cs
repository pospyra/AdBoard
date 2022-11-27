using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Domain
{
    public class SubCategory
    {

        /// <summary>
        /// Наименование подкатегории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор подкатегории
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Категогия
        /// </summary>
        public Categories Category { get; set; }
    }
}
