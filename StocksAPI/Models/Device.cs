namespace StocksAPI.Models
{
    /// <summary>
    /// Оборудование
    /// </summary>
    public class Device
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
        /// Производитель
        /// </summary>
        public required string manufacturer { get; set; }
    }
}
