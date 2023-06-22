using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StocksAPI.DataBase.Models;

public partial class Plot
{
    /// <summary>
    /// Код
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Код вида участка
    /// </summary>
    public int TypeOfPlotId { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Объект вида участка
    /// </summary>
    [JsonIgnore, AllowNull]
    public virtual TypesOfPlot? TypeOfPlot { get; set; } = null;
}
