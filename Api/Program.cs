var builder = WebApplication.CreateBuilder(args);
// Добавляем сервисы Swagger http://localhost:ПОРТ/swagger
// добавляет сервис, который генерирует описание API на основе ваших контроллеров и эндпоинтов
builder.Services.AddEndpointsApiExplorer();
// добавляет генератор Swagger, который создает спецификацию OpenAPI.
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();
// Настраиваем доступ к Swagger
// добавляет middleware для генерации JSON-документа Swagger
app.UseSwagger();
// добавляет middleware для Swagger UI - веб-интерфейса, который позволяет просматривать и тестировать ваше API
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();

