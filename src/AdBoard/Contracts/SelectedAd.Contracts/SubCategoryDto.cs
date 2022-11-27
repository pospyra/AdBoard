using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    public class SubCategoryDto
    {

      /*  /// <summary>
        /// Идентификатор категории
        /// </summary>
        public Guid CategoryId { get; set; }*/


        /// <summary>
        /// Наименование подкатегории
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Идентификатор подкатегории
        /// </summary>
        public Guid key { get; set; }

    }
}
