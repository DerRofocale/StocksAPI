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

    db.SaveChanges();
}

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
