using Microsoft.EntityFrameworkCore;
using projects.Domain.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
        Console.WriteLine("Миграции успешно применены");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка миграций: {ex.Message}");
    }
}
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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