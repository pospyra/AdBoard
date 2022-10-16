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

        //фото

        //время и дата отправки объявления

        /// <summary>
        /// Возомжность доставки
        /// </summary>
        public bool PossibleOfDelivery { get; set; }

        /// <summary>
        /// Коллекция элементов Избранных.
        /// </summary>
        public ICollection<SelectedAds> SelectedAds { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public Categories Category { get; set; }
    }
}
