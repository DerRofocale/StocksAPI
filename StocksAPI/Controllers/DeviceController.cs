using Microsoft.AspNetCore.Mvc;
using StocksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private List<Device> devices = new List<Device>();

        public DeviceController()
        {
            devices.Add(new Device() { id = 1, name = "Промышленный робот KUKA KR120 R3500", manufacturer = "Kuka ROBOTICS" });
            devices.Add(new Device() { id = 2, name = "Промышленный Робот KUKA KR120 R3100-2", manufacturer = "Kuka ROBOTICS" });
            devices.Add(new Device() { id = 3, name = "Автоматическая тележка AGV 7500 kg", manufacturer = "Kuka ROBOTICS" });
            devices.Add(new Device() { id = 4, name = "Промышленный робот KUKA KR300LP 4ax V.cpl", manufacturer = "Kuka ROBOTICS" });
            devices.Add(new Device() { id = 5, name = "Цепной конвейер для транспортировки досок", manufacturer = "" });
            devices.Add(new Device() { id = 6, name = "Строгальный станок Powermat 700", manufacturer = "WEINIG Group" });
            devices.Add(new Device() { id = 7, name = "Сканер Luxscan EasyScan", manufacturer = "WEINIG Group" });
            devices.Add(new Device() { id = 8, name = "Оптимизирующая торцовочная пила OptiCut 260", manufacturer = "WEINIG Group" });
            devices.Add(new Device() { id = 9, name = "Промышленный робот KUKA KR50 R2500", manufacturer = "Kuka ROBOTICS" });
            devices.Add(new Device() { id = 10, name = "Ручная тележка", manufacturer = "" });
            devices.Add(new Device() { id = 11, name = "Станок для обрезки углов", manufacturer = "" });
            devices.Add(new Device() { id = 12, name = "Аппарат для нанесения клейма", manufacturer = "" });
            devices.Add(new Device() { id = 13, name = "Автоматическая тележка AGV 1500 kg", manufacturer = "Kuka ROBOTICS" });
            devices.Add(new Device() { id = 14, name = "Цепной 2-ручьевой транспортёр (1т)", manufacturer = "" });
            devices.Add(new Device() { id = 15, name = "Линия расштабелирования", manufacturer = "Megapak" });
        }

        /// <summary>
        /// Оборудование
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(devices);
        }
    }
}
