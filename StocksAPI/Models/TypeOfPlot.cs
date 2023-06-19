namespace StocksAPI.Models
{
    /// <summary>
    /// Вид участка
    /// </summary>
    public class TypeOfPlot
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
