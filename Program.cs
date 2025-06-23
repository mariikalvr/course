using Microsoft.EntityFrameworkCore;
using projects.Domain.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// База данных
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Сервисы

//builder.Services.AddScoped<ICourseService, CourseService>();

// Контроллеры
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Аутентификация
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options => 
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             // Конфигурация JWT
//         };
//     });

var app = builder.Build();

// Конвейер middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();