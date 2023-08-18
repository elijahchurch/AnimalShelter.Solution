using ShelterApi.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Versioning
builder.Services.AddApiVersioning(opt =>
                {
                    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.ReportApiVersions = true;
                });

builder.Services.AddDbContext<ShelterApiContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(
                    builder.Configuration["ConnectionStrings:DefaultConnection"],
                    ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                )
            );

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
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
