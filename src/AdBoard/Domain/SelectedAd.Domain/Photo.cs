﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Domain
{
    public class Photo
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
        /// Mine type Изображения
        /// </summary>
        public string ImageMimeType { get; set; }

        /// <summary>
        /// Идентификатор Объявления
        /// </summary>
        public Guid AdId { get; set; }

        /// <summary>
        /// Объявление
        /// </summary>
        public Ads Ad { get; set; }
    }
}
