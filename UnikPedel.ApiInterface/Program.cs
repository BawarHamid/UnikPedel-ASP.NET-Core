using Microsoft.EntityFrameworkCore;
using System;
using UnikPedel.ApiInterface.Mapper;
using UnikPedel.Application;
using UnikPedel.Application.BookingContract;
using UnikPedel.Application.Contract.VicevaertInterface;
using UnikPedel.Application.EjendomContract;
using UnikPedel.Application.EjendomsAnsvarligContract;
using UnikPedel.Application.Implementation;
using UnikPedel.Application.Infrastructure;
using UnikPedel.Application.LejemaalContract;
using UnikPedel.Application.LejerContract;
using UnikPedel.Application.RekvisitionIfrastructure;
using UnikPedel.Application.RekvisitionImpimentation;
using UnikPedel.Application.TidRegistreringContract;
using UnikPedel.Domain.DomainServices;
using UnikPedel.Infrastructure.Database;
using UnikPedel.Infrastructure.DominServiceImpl;
using UnikPedel.Infrastructure.Queries;
using UnikPedel.Infrastructure.Querries;
using UnikPedel.Infrastructure.Querys;
using UnikPedel.Infrastructure.RepositoriesImpl;


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
builder.Services.AddScoped<IVicevaertQuery, VicevaertQuery>();
builder.Services.AddScoped<IVicevaertCommand, VicevaertCommands>();
builder.Services.AddScoped<IVicevaertRepository, VicevaertRepository>();
builder.Services.AddScoped<IVicevaertDomainService,VicevaertDomainService>(); 

builder.Services.AddScoped<IRekvisitionQuery, RekvisitionQuery>();
builder.Services.AddScoped<IRekvisitionCommand, RekvisitionCommand>();
builder.Services.AddScoped<IRekvisitionRepository, RekvisitionRepository>();

builder.Services.AddScoped<IEjendomQuery, EjendomQuery>();

builder.Services.AddScoped<IEjendomsAnsvarligQuery,EjendomAnsvarligQuery>();
builder.Services.AddScoped<IEjendomsAnsvarligCommand, EjendomAnsvarligCommand>();
builder.Services.AddScoped<IEjendomAnsvarligRepository,EjendomAnsavrligRepository>();

builder.Services.AddScoped<ITidRegistreringQuery, TidRegistreringQuery>();
builder.Services.AddScoped<ITidRegistreringCommand, TidRegistreringCommand>();
builder.Services.AddScoped<ITidRegistreringRepositroy, TidRegistreringRepositroy>();


builder.Services.AddScoped<IBookingQuery, BookingQuery>();
builder.Services.AddScoped<IBookingCommand, BookingCommand>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

builder.Services.AddScoped<ILejemaalQuery, LejemaalQuery>();
builder.Services.AddScoped<ILejemaalCommand, LejemaalCommand>();
builder.Services.AddScoped<ILejemaalRepository, LejemaalRepository>();

builder.Services.AddScoped<ILejerQuery, LejerQuery>();
builder.Services.AddScoped<ILejerCommand, LejerCommands>();
builder.Services.AddScoped<ILejerRepository, LejerRepository>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
