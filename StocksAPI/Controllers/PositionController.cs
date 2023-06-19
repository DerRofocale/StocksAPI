using Microsoft.AspNetCore.Mvc;
using StocksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private List<Position> positions = new List<Position>();

        public PositionController()
        {
            positions.Add(new Position() { id = 1, name = "Главный технолог" });
            positions.Add(new Position() { id = 2, name = "Старший специалист" });
            positions.Add(new Position() { id = 3, name = "Водитель спец. техники" });
            positions.Add(new Position() { id = 4, name = "Инженер-робототехник" });
            positions.Add(new Position() { id = 5, name = "Старший начальник смены" });
        }

        /// <summary>
        /// Должности
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(positions);
        }
    }
}
