using Microsoft.EntityFrameworkCore;
using ODWZ.LB1.Infrastructure.Interfaces;
using ODWZ.LB1.Infrastructure.Services;
using ODWZ.LB1.Persistence.DBContext;
using ODWZ.LB1.Persistence.Interfaces;
using ODWZ.LB1.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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