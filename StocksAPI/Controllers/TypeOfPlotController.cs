using Microsoft.AspNetCore.Mvc;
using StocksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfPlotController : ControllerBase
    {
        private List<TypeOfPlot> plots = new List<TypeOfPlot>();

        public TypeOfPlotController()
        {
            plots.Add(new TypeOfPlot() { id = 1, name = "Основной" });
            plots.Add(new TypeOfPlot() { id = 2, name = "Вспомогательный" });
        }

        /// <summary>
        /// Виды участков
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(plots);
        }
    }
}
