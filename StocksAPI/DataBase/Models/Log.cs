using System;
using System.Collections.Generic;

namespace StocksAPI.DataBase.Models;

public partial class Log
{
    /// <summary>
    /// Код
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата и время регистрации
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Субъект
    /// </summary>
    public string Subject { get; set; } = null!;
}
