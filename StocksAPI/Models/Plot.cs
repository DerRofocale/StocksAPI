namespace StocksAPI.Models
{
    /// <summary>
    /// Участок
    /// </summary>
    public class Plot
    {
        /// <summary>
        /// Код
        /// </summary>
        public required string id { get; set; }
        /// <summary>
        /// Вид участка
        /// </summary>
        public required string typeOfPlot { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public required string name { get; set; }
    }
}
