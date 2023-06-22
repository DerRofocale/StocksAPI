using System;
using System.Collections.Generic;

namespace StocksAPI.DataBase.Models;

public partial class Position
{
    /// <summary>
    /// Код
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;
}
