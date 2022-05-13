using Microsoft.EntityFrameworkCore;
using System;
using UnikPedel.ApiInterface.Mapper;
using UnikPedel.Application.Contract.Vicev�rtInterface;
using UnikPedel.Application.Implementation;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Domain.DomainServices;
using UnikPedel.Infrastructure.Database;
using UnikPedel.Infrastructure.DominServiceImpl;
using UnikPedel.Infrastructure.Queries;
using UnikPedel.Infrastructure.RepositoriesImpl;
using UnikPedel.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<UnikPedelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.MigrationsAssembly("UnikPedel.Infrastructure");
    }));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVicev�rtQuery, Vicev�rtQuery>();
builder.Services.AddScoped<IVicev�rtCommand, Vicev�rtCommands>();
builder.Services.AddScoped<IVicev�rtRepository, Vicev�rtRepository>();
builder.Services.AddScoped<IVicev�rtDomainService, Vicev�rtDomainService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<IServiceRekvisition, RekvisitionServiceProxy>();


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
