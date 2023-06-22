using Microsoft.AspNetCore.Mvc;
using StocksAPI.DataBase;
using StocksAPI.DataBase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {

        private readonly StocksContext _db;
        public PositionController(StocksContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Все должности
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_db.Positions.ToList());
        }


        /// <summary>
        /// Должность по коду
        /// </summary>
        /// <param name="id">Код должности</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (_db.Positions.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    return Ok(_db.Positions.Where(x => x.Id == id).FirstOrDefault());
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
        /// Добавление должности
        /// </summary>
        /// <param name="name">Наименование должности</param>
        [HttpPost("Add/{name}")]
        public async Task<IActionResult> Post(string name)
        {
            try
            {
                if (_db.Positions.Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    return BadRequest();
                }
                _db.Positions.Add(new Position { Name = name });
                await _db.SaveChangesAsync();
                return Ok(_db.Positions.Where(x => x.Name == name).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        /// <summary>
        /// Удаление должности
        /// </summary>
        /// <param name="id">Код должности</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_db.Positions.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    _db.Positions.Remove(_db.Positions.Where(x => x.Id == id).FirstOrDefault());
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
