namespace SelectedAd.Domain
{
    /// <summary>
    /// Избранные объявления.
    /// </summary>
    public class SelectedAds 
    {
        /// <summary>
        /// Колллекция элементов Избранных
        /// </summary>
        public List <ItemSelectedAd> Ads { get; set; } = new List<ItemSelectedAd>();

        /// <summary>
        /// Идентификатор Избранных.
        /// </summary>
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// Идентификатор Пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор Объявления
        /// </summary>
        public Guid AdId { get; set; }

        /// <summary>
        /// Объявление.
        /// </summary>
        public Ads Ad { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public Users? User { get; set; }
    }
}
