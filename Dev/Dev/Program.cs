using DeveloperStore.Sales.API.Application.Services;
using DeveloperStore.Sales.API.Infrastructure.EventPublishers;
using DeveloperStore.Sales.API.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1) Registrar dependências
builder.Services.AddSingleton<ISaleRepository, SaleRepository>();
builder.Services.AddSingleton<IEventPublisher, LogEventPublisher>();
builder.Services.AddTransient<SaleService>();

// 2) Configurar controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3) Middlewares
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();

// 4) Mapear rotas de API
app.MapControllers();

app.Run();
