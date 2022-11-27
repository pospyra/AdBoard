using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    public class ItemSelectedAdDto
    {
        /// <summary>
        /// Идентификатор элеаента коризины
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// Идентификатор вкладки избранных.
        /// </summary>
        public Guid SelectedId { get; set; }

        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid AdId { get; set; }
    }
}

