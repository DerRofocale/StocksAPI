using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "—клады API", Contact = new OpenApiContact() { Name = "ƒмитрий яльчик", Email = "dmitry_yalchik@mail.ru", } });
    try
    {
        var basePath = AppContext.BaseDirectory;
        var xmlPath = Path.Combine(basePath, "StockAPI.xml");
        x.IncludeXmlComments(xmlPath);
    }
    catch (Exception) { }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
