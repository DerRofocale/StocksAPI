using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StocksAPI.DataBase.Models;

public partial class Manufacturer
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
    /// Связаные устройства
    /// </summary>
    [JsonIgnore]
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
