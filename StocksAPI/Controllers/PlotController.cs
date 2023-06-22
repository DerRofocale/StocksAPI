using Microsoft.AspNetCore.Mvc;
using StocksAPI.DataBase;
using StocksAPI.DataBase.Models;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly StocksContext _db;
        public PlotController(StocksContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Все участки
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_db.Plots.Select(x => new {id = x.Id, typeOfPlot = x.TypeOfPlot.Name, name = x.Name}).ToList());
        }

        /// <summary>
        /// Участок по коду
        /// </summary>
        /// <param name="id">Код участка</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (_db.Plots.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    return Ok(_db.Plots.Where(x => x.Id == id).Select(x => new { id = x.Id, typeOfPlot = x.TypeOfPlot.Name, name = x.Name }).FirstOrDefault());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Добавление участка
        /// </summary>
        /// <param name="name">Наименование участка</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Plot value)
        {
            try
            {
                if (_db.Plots.Where(x => x.Name == value.Name).FirstOrDefault() != null)
                {
                    return BadRequest();
                }
                _db.Plots.Add(value);
                await _db.SaveChangesAsync();
                return Ok(_db.Plots.Where(x => x.Name == value.Name).Select(x => new { id = x.Id, typeOfPlot = x.TypeOfPlot.Name, name = x.Name }).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Удаление участка
        /// </summary>
        /// <param name="id">Код участка</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (_db.Plots.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    _db.Plots.Remove(_db.Plots.Where(x => x.Id == id).FirstOrDefault());
                    await _db.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
