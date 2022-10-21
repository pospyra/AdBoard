namespace SelectedAd.Domain
{
    /// <summary>
    /// Избранные объявления.
    /// </summary>
    public class SelectedAds 
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid AdId { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество объявлений.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Объявление.
        /// </summary>
        public Ads Ad { get; set; } 
    }
}
