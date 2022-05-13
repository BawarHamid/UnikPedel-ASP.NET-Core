using Microsoft.EntityFrameworkCore;
using System;
using UnikPedel.ApiInterface.Mapper;
using UnikPedel.Application;
using UnikPedel.Application.Contract.ViceværtInterface;
using UnikPedel.Application.Implementation;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Application.RekvisitionIfrastructure;
using UnikPedel.Application.RekvisitionImpimentation;
using UnikPedel.Application.TidRegistreringContract;
using UnikPedel.Contract.IServiceRekvisition;
using UnikPedel.Domain.DomainServices;
using UnikPedel.Infrastructure.Database;
using UnikPedel.Infrastructure.DominServiceImpl;
using UnikPedel.Infrastructure.Queries;
using UnikPedel.Infrastructure.Querries;
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
builder.Services.AddScoped<IViceværtQuery, ViceværtQuery>();
builder.Services.AddScoped<IViceværtCommand, ViceværtCommands>();
builder.Services.AddScoped<IViceværtRepository, ViceværtRepository>();
builder.Services.AddScoped<IViceværtDomainService, ViceværtDomainService>();

builder.Services.AddScoped<IRekvisitionQuery, RekvisitionQuery>();
builder.Services.AddScoped<IRekvisitionCommand, RekvisitionCommand>();
builder.Services.AddScoped<IRekvisitionRepository, RekvisitionRepository>();

builder.Services.AddScoped<ITidRegistreringQuery, TidRegistreringQuery>();
builder.Services.AddScoped<ITidRegistreringCommand, TidRegistreringCommand>();
builder.Services.AddScoped<ITidRegistreringRepositroy, TidRegistreringRepositroy>();
//builder.Services.AddScoped<ITidRegistreringDomainService, TidRegistreringDomainService>();




builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
