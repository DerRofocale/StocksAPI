using Microsoft.AspNetCore.Mvc;
using StocksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private List<Stock> stocks = new List<Stock>();

        public StockController()
        {
            stocks.Add(new Stock() { id = 1, name = "Пиломатериал", plot = "АИРП 01.00.000" });
            stocks.Add(new Stock() { id = 2, name = "Продукция", plot = "АИРП 14.00.000" });
            stocks.Add(new Stock() { id = 3, name = "Расходные материалы", plot = "АИРП 18.00.000" });
        }

        /// <summary>
        /// Склады
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(stocks);
        }
    }
}
