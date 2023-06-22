using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StocksAPI.DataBase.Models;

public partial class TypesOfPlot
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
    /// Связанные участки
    /// </summary>
    [JsonIgnore]
    public virtual ICollection<Plot> Plots { get; set; } = new List<Plot>();
}
