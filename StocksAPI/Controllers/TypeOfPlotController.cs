using Microsoft.AspNetCore.Mvc;
using StocksAPI.DataBase;
using StocksAPI.DataBase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfPlotController : ControllerBase
    {
        private readonly StocksContext _db;
        public TypeOfPlotController(StocksContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Виды участков
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_db.TypesOfPlots.ToList());
        }


        /// <summary>
        /// Вид участка по коду
        /// </summary>
        /// <param name="id">Код вида участка</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (_db.TypesOfPlots.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    return Ok(_db.TypesOfPlots.Where(x => x.Id == id).FirstOrDefault());
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
        /// Добавление вида участка
        /// </summary>
        /// <param name="name">Наименование вида участка</param>
        [HttpPost("{name}")]
        public async Task<IActionResult> Post(string name)
        {
            try
            {
                if (_db.TypesOfPlots.Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    return BadRequest();
                }
                _db.TypesOfPlots.Add(new TypesOfPlot { Name = name });
                await _db.SaveChangesAsync();
                return Ok(_db.TypesOfPlots.Where(x => x.Name == name).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Удаление вида участка
        /// </summary>
        /// <param name="id">Код вида участка</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_db.TypesOfPlots.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    _db.TypesOfPlots.Remove(_db.TypesOfPlots.Where(x => x.Id == id).FirstOrDefault());
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
