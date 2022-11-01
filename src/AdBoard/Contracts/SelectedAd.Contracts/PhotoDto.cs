using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    public class PhotoDto
    {
        /// <summary>
        /// Иденификатор фотографии.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Адрес Фото
        /// </summary>
        public byte[] LinkPhoto { get; set; }

        /// <summary>
        /// Mine type Изображение
        /// </summary>
        public string ImageMimeType { get; set; }
    }
}
