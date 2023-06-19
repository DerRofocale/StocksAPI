namespace StocksAPI.Models
{
    /// <summary>
    /// Производитель
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Код
        /// </summary>
        public required int id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public required string name { get; set; }
    }
}
