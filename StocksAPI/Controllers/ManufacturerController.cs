using Microsoft.AspNetCore.Mvc;
using StocksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private List<Manufacturer> manufacturerList = new List<Manufacturer>();

        public ManufacturerController()
        {
            manufacturerList.Add(new Manufacturer() { id = 1, name = "Kuka ROBOTICS" });
            manufacturerList.Add(new Manufacturer() { id = 2, name = "WEINIG Group" });
            manufacturerList.Add(new Manufacturer() { id = 3, name = "Megapak" });
        }

        /// <summary>
        /// Производители
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(manufacturerList);
        }
    }
}
