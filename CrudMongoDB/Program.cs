using CrudMongoDB.Models;
using CrudMongoDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.Configure<ProdutoDatabaseSettings>(
    builder.Configuration.GetSection("DotNetSettingsDatabase"));

builder.Services.AddSingleton<ProdutoService>();

// Adiciona serviços ao contêiner, como Swagger e Endpoints API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os endpoints dos controladores
app.MapControllers();

app.Run();
