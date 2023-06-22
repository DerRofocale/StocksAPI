using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StocksAPI.DataBase.Models;

public partial class Device
{
    /// <summary>
    /// Код
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Код производителя
    /// </summary>
    public int? ManufacturerId { get; set; }

    /// <summary>
    /// Объект производителя
    /// </summary>
    [JsonIgnore]
    public virtual Manufacturer? Manufacturer { get; set; }
}
