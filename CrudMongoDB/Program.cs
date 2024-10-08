using CrudMongoDB.Models;
using CrudMongoDB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProdutoDatabaseSettings>(
    builder.Configuration.GetSection("DotNetSettingsDatabase"));

builder.Services.AddSingleton<ProdutoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
