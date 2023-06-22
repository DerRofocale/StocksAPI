using Microsoft.AspNetCore.Mvc;
using StocksAPI.DataBase;
using StocksAPI.DataBase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly StocksContext _db;
        public ManufacturerController(StocksContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Все производители
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_db.Manufacturers.ToList());
        }

        /// <summary>
        /// Производитель по коду
        /// </summary>
        /// <param name="id">Код производителя</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (_db.Manufacturers.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    return Ok(_db.Manufacturers.Where(x => x.Id == id).FirstOrDefault());
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
        /// Добавление производителя
        /// </summary>
        /// <param name="name">Наименование производителя</param>
        [HttpPost("{name}")]
        public async Task<IActionResult> Post(string name)
        {
            try
            {
                if (_db.Manufacturers.Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    return BadRequest();
                }
                _db.Manufacturers.Add(new Manufacturer { Name = name });
                await _db.SaveChangesAsync();
                return Ok(_db.Manufacturers.Where(x => x.Name == name).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id">Код производителя</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_db.Manufacturers.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    _db.Manufacturers.Remove(_db.Manufacturers.Where(x => x.Id == id).FirstOrDefault());
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
