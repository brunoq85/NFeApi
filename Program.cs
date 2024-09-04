using Microsoft.EntityFrameworkCore;
using NFeApi.AutoMapper;
using NFeApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração do DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NFeContext")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers().AddXmlSerializerFormatters();

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
