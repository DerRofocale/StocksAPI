namespace StocksAPI.Models
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Код
        /// </summary>
        public required int id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public required string name { get; set; }
        /// <summary>
        /// Участок
        /// </summary>
        public required string plot { get; set; }
    }
}
