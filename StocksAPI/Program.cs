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
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "������ API", Contact = new OpenApiContact() { Name = "������� ������", Email = "dmitry_yalchik@mail.ru", } });
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
    db.Positions.Add(new Position() { Name = "������� ��������" });
    db.Positions.Add(new Position() { Name = "������� ����������" });
    db.Positions.Add(new Position() { Name = "�������� ����. �������" });
    db.Positions.Add(new Position() { Name = "�������-������������" });
    db.Positions.Add(new Position() { Name = "������� ��������� �����" });

    db.TypesOfPlots.Add(new TypesOfPlot() { Name = "��������" });
    db.TypesOfPlots.Add(new TypesOfPlot() { Name = "���������������" });

    db.Manufacturers.Add(new Manufacturer() { Name = "Kuka ROBOTICS" });
    db.Manufacturers.Add(new Manufacturer() { Name = "WEINIG Group" });
    db.Manufacturers.Add(new Manufacturer() { Name = "Megapak" });

    db.Devices.Add(new Device() { Id = 1, Name = "������������ ����� KUKA KR120 R3500", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 2, Name = "������������ ����� KUKA KR120 R3100-2", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 3, Name = "�������������� ������� AGV 7500 kg", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 4, Name = "������������ ����� KUKA KR300LP 4ax V.cpl", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 5, Name = "������ �������� ��� ��������������� �����", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 6, Name = "����������� ������ Powermat 700", ManufacturerId = 2 });
    db.Devices.Add(new Device() { Id = 7, Name = "������ Luxscan EasyScan", ManufacturerId = 2 });
    db.Devices.Add(new Device() { Id = 8, Name = "�������������� ����������� ���� OptiCut 260", ManufacturerId = 2 });
    db.Devices.Add(new Device() { Id = 9, Name = "������������ ����� KUKA KR50 R2500", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 10, Name = "������ �������", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 11, Name = "������ ��� ������� �����", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 12, Name = "������� ��� ��������� ������", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 13, Name = "�������������� ������� AGV 1500 kg", ManufacturerId = 1 });
    db.Devices.Add(new Device() { Id = 14, Name = "������ 2-�������� ���������� (1�)", ManufacturerId = null });
    db.Devices.Add(new Device() { Id = 15, Name = "����� �����������������", ManufacturerId = 3 });

    db.Plots.Add(new Plot() { Id = "���� 01.00.000", Name = "����� ��������������", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "���� 02.00.000", Name = "��������������", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "���� 04.00.000", Name = "����� ��������������", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "���� 06.00.000", Name = "������������� �����", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "���� 10.00.000", Name = "����� ������ �������� (������� ���������)", TypeOfPlotId = 1 });
    db.Plots.Add(new Plot() { Id = "���� 14.00.000", Name = "����� ������� ���������", TypeOfPlotId = 1 });

    db.SaveChanges();
}

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
