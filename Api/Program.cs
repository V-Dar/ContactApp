var builder = WebApplication.CreateBuilder(args);
// Добавляем сервисы Swagger http://localhost:ПОРТ/swagger
// добавляет сервис, который генерирует описание API на основе ваших контроллеров и эндпоинтов
builder.Services.AddEndpointsApiExplorer();
// добавляет генератор Swagger, который создает спецификацию OpenAPI.
builder.Services.AddSwaggerGen();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.MapOpenApi();
// Настраиваем доступ к Swagger
// добавляет middleware для генерации JSON-документа Swagger
app.UseSwagger();
// добавляет middleware для Swagger UI - веб-интерфейса, который позволяет просматривать и тестировать ваше API
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("/test", () => "Hello world!");
app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");

app.Run();

