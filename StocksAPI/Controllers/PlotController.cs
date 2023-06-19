using Microsoft.AspNetCore.Mvc;
using StocksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private List<Plot> plots = new List<Plot>();

        public PlotController()
        {
            plots.Add(new Plot() { id = "АИРП 01.00.000", typeOfPlot = "Основной", name = "Склад Пиломатериалов" });
            plots.Add(new Plot() { id = "АИРП 02.00.000", typeOfPlot = "Основной", name = "Штабелирование" });
            plots.Add(new Plot() { id = "АИРП 04.00.000", typeOfPlot = "Основной", name = "Сушка пиломатериалов" });
            plots.Add(new Plot() { id = "АИРП 06.00.000", typeOfPlot = "Основной", name = "Распиловочная линия" });
            plots.Add(new Plot() { id = "АИРП 10.00.000", typeOfPlot = "Основной", name = "Линия сборки поддонов (готовой продукции)" });
            plots.Add(new Plot() { id = "АИРП 14.00.000", typeOfPlot = "Основной", name = "Склад готовой продукции" });
            plots.Add(new Plot() { id = "АИРП 18.00.000", typeOfPlot = "Основной", name = "Расходные материалы" });
        }

        /// <summary>
        /// Участки
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(plots);
        }
    }
}
