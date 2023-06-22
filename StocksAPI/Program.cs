using Microsoft.OpenApi.Models;
using StocksAPI.DataBase;
using StocksAPI.DataBase.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StocksContext>();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Склады API", Contact = new OpenApiContact() { Name = "Дмитрий Яльчик", Email = "dmitry_yalchik@mail.ru", } });
    try
    {
        var basePath = AppContext.BaseDirectory;
        var xmlPath = Path.Combine(basePath, "StockAPI.xml");
        x.IncludeXmlComments(xmlPath);
    }
    catch (Exception) { }
});

using(StocksContext db = new StocksContext())
{
    db.Positions.Add(new Position() { Name = "Главный технолог" });
    db.Positions.Add(new Position() { Name = "Старший специалист" });
    db.Positions.Add(new Position() { Name = "Водитель спец. техники" });
    db.Positions.Add(new Position() { Name = "Инженер-робототехник" });
    db.Positions.Add(new Position() { Name = "Старший начальник смены" });

    db.TypesOfPlots.Add(new TypesOfPlot() { Name = "Основной" });
    db.TypesOfPlots.Add(new TypesOfPlot() { Name = "Вспомогательный" });

    db.Manufacturers.Add(new Manufacturer() { Name = "Kuka ROBOTICS" });
    db.Manufacturers.Add(new Manufacturer() { Name = "WEINIG Group" });
    db.Manufacturers.Add(new Manufacturer() { Name = "Megapak" });

    db.Devices.Add(new Device() { Id = 1, Name = "Промышленный робот KUKA KR120 R3500", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 2, Name = "Промышленный Робот KUKA KR120 R3100-2", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 3, Name = "Автоматическая тележка AGV 7500 kg", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 4, Name = "Промышленный робот KUKA KR300LP 4ax V.cpl", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 5, Name = "Цепной конвейер для транспортировки досок", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 6, Name = "Строгальный станок Powermat 700", ManufacturerId = 2 });
    db.Devices.Add(new Device() { Id = 7, Name = "Сканер Luxscan EasyScan", ManufacturerId = 2 });
    db.Devices.Add(new Device() { Id = 8, Name = "Оптимизирующая торцовочная пила OptiCut 260", ManufacturerId = 2 });
    db.Devices.Add(new Device() { Id = 9, Name = "Промышленный робот KUKA KR50 R2500", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 10, Name = "Ручная тележка", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 11, Name = "Станок для обрезки углов", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 12, Name = "Аппарат для нанесения клейма", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 13, Name = "Автоматическая тележка AGV 1500 kg", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 14, Name = "Цепной 2-ручьевой транспортёр (1т)", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 15, Name = "Линия расштабелирования", ManufacturerId = 3 });

    db.Plots.Add(new Plot() { Id = "АИРП 01.00.000", Name = "Склад Пиломатериалов", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "АИРП 02.00.000", Name = "Штабелирование", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "АИРП 04.00.000", Name = "Сушка пиломатериалов", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "АИРП 06.00.000", Name = "Распиловочная линия", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "АИРП 10.00.000", Name = "Линия сборки поддонов (готовой продукции)", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "АИРП 14.00.000", Name = "Склад готовой продукции", TypeOfPlotId = 1 });

    db.SaveChanges();
}

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
