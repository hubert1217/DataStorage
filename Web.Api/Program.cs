using Microsoft.EntityFrameworkCore;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Services;
using Web.Infrastructure.Database;
using Web.Infrastructure.Database.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:59311") // Dostosuj do swojego frontendu
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

//Add DI association
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDao, UserDao>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataStorageAppContext>(options =>
    options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=DataStorageApp;Trusted_Connection=True;TrustServerCertificate=True;"));




var app = builder.Build();

app.UseCors("AllowFrontend");

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
