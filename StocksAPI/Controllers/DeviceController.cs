using Microsoft.AspNetCore.Mvc;
using StocksAPI.DataBase;
using StocksAPI.DataBase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly StocksContext _db;
        public DeviceController(StocksContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Всё оборудование
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_db.Devices.Select(x => new { id = x.Id, name = x.Name, manufacturer = x.Manufacturer.Name != null ? x.Manufacturer.Name : null }).ToList());
        }

        /// <summary>
        /// Оборудование по коду
        /// </summary>
        /// <param name="id">Код оборудования</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (_db.Devices.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    return Ok(_db.Devices.Where(x => x.Id == id).Select(x => new { id = x.Id, name = x.Name, manufacturer = x.Manufacturer.Name != null ? x.Manufacturer.Name : null }).FirstOrDefault());
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
        /// Добавление оборудования
        /// </summary>
        /// <param name="name">Наименование оборудования</param>
        [HttpPost("{name}/{manufacturerid}")]
        public async Task<IActionResult> Post(string name, int manufacturerid)
        {
            try
            {
                if (_db.Devices.Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    return BadRequest();
                }
                _db.Devices.Add(new Device()
                {
                    Name = name,
                    ManufacturerId = manufacturerid
                });
                await _db.SaveChangesAsync();
                return Ok(_db.Devices.Where(x => x.Name == name).Select(x => new { id = x.Id, name = x.Name, manufacturer = x.Manufacturer.Name != null ? x.Manufacturer.Name : null }).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Удаление оборудования
        /// </summary>
        /// <param name="id">Код оборудования</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_db.Devices.Where(x => x.Id == id).FirstOrDefault() != null)
                {
                    _db.Devices.Remove(_db.Devices.Where(x => x.Id == id).FirstOrDefault());
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
